using System.Collections.Generic;
using System.Web.Mvc;

namespace LMS.App.Web.Models
{
    public class UserGoalsViewModel
    {
        public UserGoalsViewModel()
        {
            Qualificationslist = new List<QualificationView>();
        }

        public string GoalName { get; set; }
        public string Description { get; set; }
        public bool? Acheived { get; set; }
        public int QualificationId { get; set; }
        public List<QualificationView> Qualificationslist { get; set; }

    }
    public class QualificationView
    {
        public QualificationView()
        {

        }
        public int Id { get; set; }
        public int QualificationId { get; set; }
        public string QualificationName { get; set; }
        public string QualificationCode { get; set; }
        public string Remarks { get; set; }

        public int ColorId { get; set; }
        public int FontColorCardId { get; set; }
       
    }
    public class QualificationMasterView
    {
        public QualificationMasterView()
        {

        }
        public int Id { get; set; }
        public int QualificationId { get; set; }
        public string QualificationName { get; set; }
        public string QualificationCode { get; set; }
        public string Remarks { get; set; }

        public int ColorId { get; set; }
        public int FontColorCardId { get; set; }


    }
    

}