using FluentValidation;

namespace FootballShopBackend.Application.Features.Teams.Commands.CreateTeam
{
    public class CreateTeamCommandValidator : AbstractValidator<CreateTeamCommand>
    {
        public CreateTeamCommandValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Name is required.")
                .MaximumLength(100).WithMessage("Name cannot exceed 100 characters.");
            RuleFor(x => x.Country)
                .NotEmpty().WithMessage("Country is required.")
                .MaximumLength(100).WithMessage("Country cannot exceed 100 characters.");
            RuleFor(x => x.LogoUrl)
                .NotEmpty().WithMessage("Logo URL is required.")
                .MaximumLength(200).WithMessage("Logo URL cannot exceed 200 characters.");
            RuleFor(x => x.LeagueId)
                .NotEmpty().WithMessage("League ID is required.");
        }
    }
}
