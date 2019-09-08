using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LMS.App.Web.Models
{
    public class UserQualificationsView
    {
        public UserQualificationsView()
        {
            QualificaitonList = new List<SelectListItem>();
        }
        public int Qid { get; set; }
        public IEnumerable<SelectListItem> QualificaitonList { get; set; }
        public string FullName { get; set; }
        public string Description { get; set; }
    }
}