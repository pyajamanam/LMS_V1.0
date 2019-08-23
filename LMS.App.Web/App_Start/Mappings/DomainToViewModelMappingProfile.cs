using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using AutoMapper.Mappers;
using LMS.App.Core.Data.Entities;
using LMS.App.Web.Models;

namespace LMS.App.Web.App_Start.Mappings
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public override string ProfileName => "DomainToViewModelMappingProfile";
        public DomainToViewModelMappingProfile()
        {
            AddConditionalObjectMapper().Where((s, d) => s.Namespace != "System.Data.Entity.DynamicProxies" && d.Namespace != "System.Data.Entity.DynamicProxies");

            CreateMap<User, UserViewModel>()
              .ForMember(dest => dest.Country,
              opt => opt.MapFrom(src => src.Company.CompanyName))
              .ForMember(dest => dest.Company, opt => opt.MapFrom(src => src.Company.CompanyName));

            CreateMap<Company, CompanyViewModel>()
                .ForMember(dest => dest.CompanyName,
                opt => opt.MapFrom(src => src.CompanyName));

            CreateMap<Country, CountryViewModel>()
                .ForMember(dest => dest.CountryName,
                opt => opt.MapFrom(src => src.CountryName));
        }
    }

}