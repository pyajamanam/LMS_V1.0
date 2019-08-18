using AutoMapper;
using LMS.App.Core.Data.Entities;
using LMS.App.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LMS.App.Web.App_Start.Mappings
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public override string ProfileName => "ViewModelToDomainMappingProfile";
        public ViewModelToDomainMappingProfile()
        {
            CreateMap<UserViewModel, User>()
                .ForMember(src => src.Roles, opt => opt.Ignore())
                .ForMember(src => src.CompanyId, opt => opt.MapFrom(dest => dest.Country));

            CreateMap<RegisterModel, User>()
                .ForMember(src => src.CompanyId, opt => opt.MapFrom(dest => dest.CompanyId))
                .ForMember(src => src.CountryId, opt => opt.MapFrom(dest => dest.CountryId))
               .ForMember(src => src.Company, opt => opt.Ignore())
               .ForMember(src => src.Country, opt => opt.Ignore());

        }
    }
}