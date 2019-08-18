using LMS.App.Core.Data.Contexts;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

[assembly: PreApplicationStartMethod(typeof(LMS.App.Core.Data.Startup), "Start")]

namespace LMS.App.Core.Data
{
    public class Startup
    {
        public static void Start()
        {
            Database.SetInitializer(new LMSInitializer());
            //Database.SetInitializer<LMSContext>(new DropCreateDatabaseIfModelChanges<LMSContext>());
            // do some awesome stuff here!
        }
       
    }
}
