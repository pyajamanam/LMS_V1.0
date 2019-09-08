using LMS.App.Core.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.App.Core.Data.Repositories.Abstractions
{
   public interface ICourseRepository: IDisposable
    {
        bool CreateCourse(Course course );
        bool EditCourse(int Id);
        bool UpdateCourse(Course course);

        bool DeleteCourse(int Id);
    }
}
