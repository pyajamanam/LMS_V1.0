using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LMS.App.Web.Models
{
    public class CountryViewModel
    {
        public int CountryId { get; set; }
        public string CountryName { get; set; }
        //public string Address { get; set; }
        public bool IsDeleted { get; set; }

    }
}