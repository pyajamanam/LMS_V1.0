using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LMS.App.Web.Models
{
    public class CompanyViewModel
    {
        public int CompanyId { get; set; }
        public string CompanyName { get; set; }
        public string Address { get; set; }
        public string Remark { get; set; }

    }
}