using LMS.App.Core.Data.Contexts;
using LMS.App.Core.Data.Entities;
using LMS.App.Core.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.App.Core.Data
{
    public class UnitOfWork : IDisposable
    {
        private LMSContext context = new LMSContext();
        private readonly GenericRepository<User> userRepository;
        private readonly GenericRepository<Role> roleRepository;
        private readonly GenericRepository<Course> courseRepository;
        private readonly GenericRepository<Company> companyRepository;
        private readonly GenericRepository<Qualification> qualificationRepository;

        public GenericRepository<User> UserRepository
        {
            get
            {
                return userRepository ?? new GenericRepository<User>(context);
            }
        }

        public GenericRepository<Qualification> QualificationRepository
        {
            get
            {
                return qualificationRepository ?? new GenericRepository<Qualification>(context);
            }
        }
        public GenericRepository<Role> RoleRepository
        {
            get
            {
                return roleRepository ?? new GenericRepository<Role>(context);
            }
        }

        public GenericRepository<Course> CourseRepository
        {
            get
            {
                return courseRepository ?? new GenericRepository<Course>(context);
            }
        }

        public GenericRepository<Company> CompanyRepository
        {
            get
            {
                return companyRepository ?? new GenericRepository<Company>(context);
            }
        }
        public int Save()
        {
          return  context.SaveChanges();
        }
        private bool disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
