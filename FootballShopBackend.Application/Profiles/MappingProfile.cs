using AutoMapper;
using FootballShopBackend.Application.Features.Auth.Commands.Login;
using FootballShopBackend.Application.Features.Auth.Commands.Register;
using FootballShopBackend.Application.Features.Leagues.Commands.CreateLeague;
using FootballShopBackend.Application.Features.Leagues.Queries.GetLeagueDetail;
using FootballShopBackend.Application.Features.Leagues.Queries.GetLeaguesList;
using FootballShopBackend.Application.Features.Products.Commands.CreateProduct;
using FootballShopBackend.Application.Features.Products.Commands.UpdateProduct;
using FootballShopBackend.Application.Features.Products.Queries.GetCoursesList;
using FootballShopBackend.Application.Features.Products.Queries.GetProductDetail;
using FootballShopBackend.Application.Features.Review.Queries.GetReviewsList;
using FootballShopBackend.Application.Features.Reviews.Commands.CreateReview;
using FootballShopBackend.Application.Features.Reviews.Commands.UpdateReview;
using FootballShopBackend.Application.Features.Reviews.Queries.GetReviewDetail;
using FootballShopBackend.Application.Features.Teams.Commands.CreateTeam;
using FootballShopBackend.Application.Features.Teams.Commands.UpdateTeam;
using FootballShopBackend.Application.Features.Teams.Queries.GetTeamDetail;
using FootballShopBackend.Application.Features.Teams.Queries.GetTeamsList;
using FootballShopBackend.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballShopBackend.Application.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {

            CreateMap<Review, ReviewListVm>()
                .ForMember(dest => dest.AuthorName, opt => opt.MapFrom(src => src.Author.Name + " " + src.Author.Surname))
                .ForMember(dest => dest.ProductName, opt => opt.MapFrom(src => src.Product.Name));

            CreateMap<Review, ReviewDetailVm>()
                .ForMember(dest => dest.AuthorName, opt => opt.MapFrom(src => src.Author.Name + " " + src.Author.Surname))
                .ForMember(dest => dest.ProductName, opt => opt.MapFrom(src => src.Product.Name));

            CreateMap<CreateReviewCommand, Review>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => Guid.NewGuid()))
                .ForMember(dest => dest.PublicationDate, opt => opt.MapFrom(src => DateTime.UtcNow));

            CreateMap<UpdateReviewCommand, Review>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.ReviewId));

            CreateMap<Product, ProductListVm>()
                .ForMember(dest => dest.TeamName, opt => opt.MapFrom(src => src.Team.Name));

            CreateMap<Product, ProductDetailVm>()
                .ForMember(dest => dest.TeamName, opt => opt.MapFrom(src => src.Team.Name))
                .ForMember(dest => dest.LeagueName, opt => opt.MapFrom(src => src.Team.League.Name));

            CreateMap<CreateProductCommand, Product>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => Guid.NewGuid()));

            CreateMap<UpdateProductCommand, Product>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.ProductId));

            CreateMap<League, LeagueVm>();

            CreateMap<League, LeagueDetailVm>();

            CreateMap<CreateLeagueCommand, League>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => Guid.NewGuid()));

            CreateMap<UpdateProductCommand, Product>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.ProductId));

            CreateMap<Team, TeamListVm>()
                .ForMember(dest => dest.LeagueName, opt => opt.MapFrom(src => src.League.Name));

            CreateMap<Team, TeamDetailVm>()
                .ForMember(dest => dest.LeagueName, opt => opt.MapFrom(src => src.League.Name));

            CreateMap<CreateTeamCommand, Team>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => Guid.NewGuid()));

            CreateMap<UpdateTeamCommand, Team>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id));

            CreateMap<RegisterCommand, RegisterUserVM>();

            CreateMap<LoginCommand, LoginUserVM>();

        }

    }
}
