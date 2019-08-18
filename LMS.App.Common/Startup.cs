using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

//[assembly: PreApplicationStartMethod(typeof(LMS.App.Common.Startup), "Start")]//[assembly: PreApplicationStartMethod(typeof(LMS.App.Common.Startup), "Start")]

namespace LMS.App.Common
{
    public class Startup
    {
        public static void Start()
        {
            log4net.Config.XmlConfigurator.Configure();
            // do some awesome stuff here!
        }

    }
}
