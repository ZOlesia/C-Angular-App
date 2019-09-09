using System.Linq;
using API.Dtos;
using API.Models;
using AutoMapper;

namespace API.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<User, UserForListDto>()
                .ForMember(dest => dest.PhotoUrl, opt => {
                    opt.MapFrom(src => src.Photos.FirstOrDefault(p => p.IsMain).Url);
                })
                .ForMember(dest => dest.Age, opt => {
                    opt.ResolveUsing(d => d.DateofBirth.CalculateAge());
                });

            CreateMap<User, UserForDetailsDto>()
                .ForMember(dest => dest.PhotoUrl, opt => {
                        opt.MapFrom(src => src.Photos.FirstOrDefault(p => p.IsMain).Url);
                    })
                    .ForMember(dest => dest.Age, opt => {
                    opt.ResolveUsing(d => d.DateofBirth.CalculateAge());
                });

            CreateMap<Photo, PhotoForDetailsDto>();
            CreateMap<UserForUpdateDto, User>();
        }
    }
}