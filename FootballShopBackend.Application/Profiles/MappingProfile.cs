using AutoMapper;
using FootballShopBackend.Application.Features.Reviews.Commands.CreateReview;
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
            CreateMap<CreateReviewCommand, Review>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => Guid.NewGuid()))
                .ForMember(dest => dest.PublicationDate, opt => opt.MapFrom(src => DateTime.UtcNow));
        }

    }
}
