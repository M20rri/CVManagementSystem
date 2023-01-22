using AutoMapper;
using CVManagementSystem.Dto;
using CVManagementSystem.Models;

namespace CVManagementSystem.Mappings
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<ExperienceInformation, ExperienceInformationDto>()
           .ForMember(dest => dest.Id, target => target.MapFrom(src => src.Id))
           .ForMember(dest => dest.City, target => target.MapFrom(src => src.City))
           .ForMember(dest => dest.CompanyField, target => target.MapFrom(src => src.CompanyField))
           .ForMember(dest => dest.CompanyName, target => target.MapFrom(src => src.CompanyName)).ReverseMap();


            CreateMap<PersonalInformation, PersonalInformationDto>()
           .ForMember(dest => dest.Id, target => target.MapFrom(src => src.Id))
           .ForMember(dest => dest.Fullname, target => target.MapFrom(src => src.Fullname))
           .ForMember(dest => dest.Cityname, target => target.MapFrom(src => src.Cityname))
           .ForMember(dest => dest.Email, target => target.MapFrom(src => src.Email))
           .ForMember(dest => dest.Mobile, target => target.MapFrom(src => src.Mobile)).ReverseMap();


            CreateMap<CV, CVDto>()
           .ForMember(dest => dest.Id, target => target.MapFrom(src => src.Id))
           .ForMember(dest => dest.Name, target => target.MapFrom(src => src.Name))
           .ForMember(dest => dest.Experience_Information_Id, target => target.MapFrom(src => src.Experience_Information_Id))
           .ForMember(dest => dest.Personal_Information_Id, target => target.MapFrom(src => src.Personal_Information_Id)).ReverseMap();

            CreateMap<CV, CVDtoPage>()
           .ForMember(dest => dest.Id, target => target.MapFrom(src => src.Id))
           .ForMember(dest => dest.Personal_Information, target => target.MapFrom(src => src.Personal_Information))
           .ForMember(dest => dest.Experience_Information, target => target.MapFrom(src => src.Experience_Information))
           .ForMember(dest => dest.Name, target => target.MapFrom(src => src.Name))
           .ForMember(dest => dest.Experience_Information_Id, target => target.MapFrom(src => src.Experience_Information_Id))
           .ForMember(dest => dest.Personal_Information_Id, target => target.MapFrom(src => src.Personal_Information_Id)).ReverseMap();


        }
    }
}
