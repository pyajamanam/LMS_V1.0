using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
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

            CreateMap<Course, CourseViewModel>()
               .ForMember(dest => dest.CourseCode,
               opt => opt.MapFrom(src => src.CourseCode))
            .ForMember(dest => dest.CourseName,
               opt => opt.MapFrom(src => src.CourseName))
               .ForMember(dest => dest.Status,
               opt => opt.MapFrom(src => src.Status))
              .ForMember(dest => dest.Course, opt => opt.MapFrom(src => src.CourseParent.CourseName));


            CreateMap<Qualification, QualificationView>()
                .ForMember(dest => dest.QualificationId, opt => opt.MapFrom(src => src.QualificationId))
                 .ForMember(dest => dest.QualificationName, opt => opt.MapFrom(src => string.Format("{0}-{1}", src.QualificationCode, src.QualificationName)))
                 .ForMember(dest => dest.Remarks, opt => opt.MapFrom(src =>  src.Remarks));

            CreateMap<Qualification, UserQualificationsView>()
               .ForMember(dest => dest.Qid, opt => opt.MapFrom(src => src.QualificationId))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => string.Format("{0}-{1}", src.QualificationCode, src.QualificationName)));

                CreateMap<User, UserQualificationsView>()
               .ForMember(dest => dest.FullName, opt => opt.MapFrom(src => src.UserDetails.FullName));

            CreateMap<Qualification, QualificationMasterView>()
                .ForMember(dest => dest.QualificationId, opt => opt.MapFrom(src => src.QualificationId))
                 .ForMember(dest => dest.QualificationName, opt => opt.MapFrom(src => string.Format("{0}-{1}", src.QualificationCode, src.QualificationName)))
                 .ForMember(dest => dest.Remarks, opt => opt.MapFrom(src => src.Remarks));

            CreateMap<User, UserGoalsViewModel>()
             .ForMember(dest => dest.GoalName,
             opt => opt.MapFrom(src => src.Qualifications.Select(x => x.QualificationName).ToString()))
             .ForMember(dest => dest.Description,
             opt => opt.MapFrom(src => src.Qualifications.Select(x => x.Remarks)))
             .ForMember(dest => dest.Acheived,
             opt => opt.MapFrom(src => false))
              .ForMember(dest => dest.Qualificationslist,
             opt => opt.MapFrom(src => src.Qualifications.ToList()));



        }
    }

}