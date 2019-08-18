using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.App.Common.Helpers
{
    public class SecurityHelper
    {
        public static bool IsAdmin
        {
            get; set;

        }
        public static bool IsAuthedicated
        { get; set; }
        public static bool IsTrainer { get; set; }
        public static bool IsTrainee { get; set; }

    }
}
