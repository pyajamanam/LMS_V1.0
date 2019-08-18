using AutoMapper;
using LMS.App.Web.App_Start.Mappings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LMS.App.Web.App_Start
{
    public class MapperConfig
    {
        public static void Configure()
        {
            Mapper.Initialize(x =>
            {
                x.AddProfile<ViewModelToDomainMappingProfile>();
                x.AddProfile<DomainToViewModelMappingProfile>();
            });
        }
    }
}