using LMS.App.Core.Data.Contexts;
using LMS.App.Core.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using LMS.App.Core.Data.Repositories;
using System.Data.Entity;
using LMS.App.Core.Data.Repositories.Abstractions;

namespace LMS.App.Core.Data.Repositories
{
    public class CourseRepository : ICourseRepository, IDisposable
    {
        private readonly LMSContext _db;

        private bool _disposed = false;

        public CourseRepository()
        {
            _db = new LMSContext();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
        private bool disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _db.Dispose();
                }
            }
            this.disposed = true;
        }

        public bool CreateCourse(Course course)
        {
            throw new NotImplementedException();
        }

        public bool EditCourse(int Id)
        {
            throw new NotImplementedException();
        }

        public bool UpdateCourse(Course course)
        {
            throw new NotImplementedException();
        }

        public bool DeleteCourse(int Id)
        {
            throw new NotImplementedException();
        }

        public bool CreateCourse()
        {
            throw new NotImplementedException();
        }
    }
}

