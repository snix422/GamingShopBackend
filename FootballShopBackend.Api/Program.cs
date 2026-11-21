using FootballShopBackend.Api.Middlewares;
using FootballShopBackend.Application;
using Hangfire;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Data.SqlClient;
using Serilog;
using System.Data.Entity;

var builder = WebApplication.CreateBuilder(args);

var jwtKeyFile = builder.Configuration["Jwt:KeyFile"] ?? "/run/secrets/jwt_key";

if(File.Exists(jwtKeyFile))
{
    builder.Configuration["Jwt:Key"] = File.ReadAllText(jwtKeyFile).Trim();
}

var jwtKey = builder.Configuration["Jwt:Key"];

if (string.IsNullOrWhiteSpace(jwtKey))
{
    throw new Exception("JWT key is not set. Please provide a valid key in the configuration or in the secrets file.");
}

if (System.Text.Encoding.UTF8.GetByteCount(jwtKey) < 32)
{
    throw new Exception("Jwt key is too short. It must be at least 32 characters long for security reasons");
}

var smtpPasswordFile = builder.Configuration["SmtpSettings:PasswordFile"] ?? "/run/secrets/smtp_password";

if (File.Exists(smtpPasswordFile))
{
    builder.Configuration["SmtpSettings:Password"] = File.ReadAllText(smtpPasswordFile).Trim();
}

var dbPasswordFile = builder.Configuration["Dbsettings:PasswordFile"] ?? "/run/secrets/db_password";

if(File.Exists(dbPasswordFile))
{
    var csb = new SqlConnectionStringBuilder(builder.Configuration.GetConnectionString("DefaultConnection"))
    {
        Password = File.ReadAllText(dbPasswordFile).Trim()
    };

    builder.Configuration["ConnectionStrings:DefaultConnection"] = csb.ConnectionString;

}

builder.Host.UseSerilog((context, configuration) =>
    configuration.ReadFrom.Configuration(context.Configuration));

builder.Services.AddHttpContextAccessor();
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowFrontend",
       policy =>
       {
           policy.WithOrigins("http://localhost:5173", "http://localhost:3000")
                 .AllowAnyHeader()
                 .AllowAnyMethod()
                 .AllowCredentials();
       });
});

builder.Services.AddRouting(options => {
    options.LowercaseUrls = true;
});

builder.Services.AddHangfire(configuration => configuration
    .SetDataCompatibilityLevel(CompatibilityLevel.Version_180)
    .UseSimpleAssemblyNameTypeSerializer()
    .UseRecommendedSerializerSettings()
    .UseSqlServerStorage(builder.Configuration.GetConnectionString("DefaultConnection")));

EnsureDatabaseExists(builder.Configuration.GetConnectionString("DefaultConnection"));
builder.Services.AddHangfireServer();

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddAuthorization(options =>
{
    options.FallbackPolicy = new AuthorizationPolicyBuilder()
        .RequireAuthenticatedUser()
        .Build();
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddApplication();
builder.Services.AddInfrastracture(builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseMiddleware<ErrorHandlingMiddleware>();
app.UseSerilogRequestLogging();
app.UseHttpsRedirection();
app.UseRouting();
app.UseCors("AllowFrontend");
app.UseAuthentication();
app.UseAuthorization();

IDashboardAuthorizationFilter dashboardAuth = app.Environment.IsDevelopment()
    ? new AllowAllDashboardAuthorizationFilter()
    : new AdminDashboardAuthorizationFilter();
app.UseHangfireDashboard("/hangfire", new DashboardOptions
{
    Authorization = new[] { dashboardAuth }
});

app.MapControllers();

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<Context>();
    for (int attempts = 0; attempts < 5; attempts++)
    {
        try
        {
            db.Database.Migrate();
            break;
        }
        catch when (attempts < 5)
        {
            Thread.Sleep(TimeSpan.FromSeconds(5));
            throw;
        }
    }
}

app.Run();

static void EnsureDatabaseExists(string connectionString)
{
var database = new SqlConnectionStringBuilder(connectionString).InitialCatalog;
var masterConnectionString = new SqlConnectionStringBuilder(connectionString)
{
InitialCatalog = "master"
}.ConnectionString;

for (int attempt = 1; ; attempt++)
{
try
{
using var connection = new SqlConnection(masterConnectionString);
connection.Open();
using var command = connection.CreateCommand();
command.CommandText = $"IF DB_ID(@name) IS NULL CREATE DATABASE [{database}];";
command.Parameters.AddWithValue("@name", database);
command.ExecuteNonQuery();
return;

}
catch (SqlException ex) when (attempt < 10)
{
Thread.Sleep(TimeSpan.FromSeconds(3));
}

}

}

public partial class Program { }
