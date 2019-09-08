using LMS.App.Core.Data.Contexts;
using LMS.App.Core.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using LMS.App.Core.Data.Repositories;
using System.Data.Entity;

namespace LMS.App.Core.Data.Repositories
{
    public class CountryRepository : ICountryRepository, IDisposable
    {
        private readonly LMSContext _db;

        private bool _disposed = false;

        public CountryRepository()
        {
            _db = new LMSContext();
        }



        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
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

        public List<Role> GetRoles()
        {
            return _db.Roles.ToList();
        }

        

        public bool Add(Company company)
        {
            _db.Companies.Add(company);
            return _db.SaveChanges() > 0 ? true : false;
        }
        public bool Delete(int companyId)
        {
            var company = _db.Companies.Where(x => x.CompanyId == companyId).FirstOrDefault();
            if (company == null)
                return false;
            _db.Companies.Remove(company);
            return _db.SaveChanges() > 0 ? true : false;
        }
        public Company Edit(int compid)
        {
            var compnay = _db.Companies.Where(x => x.CompanyId == compid).FirstOrDefault();
            return compnay;
        }
        public bool Update(Company company)
        {
            //_db.Companies.Add(new Company() { Address = company.Address, CompanyName = company.CompanyName, Remark = company.Remark });
           _db.Entry(company).State = EntityState.Modified;
            return _db.SaveChanges() > 0 ? true : false;
            //return compnay;
        }

        
        public string[] GetRolesforUser(string username)
        {
            throw new NotImplementedException();
        }

        public User GetUser(string userName)
        {
            var user = _db.Users.SingleOrDefault(u => u.UserName == userName);
            return user;

        }

       

        public List<Country> GeCountries()
        {
            var countries = _db.Countries.Where(x => !x.IsDeleted).ToList();
            return countries;
        }

        public bool Add(Country company)
        {
            throw new NotImplementedException();
        }

        public bool Update(Country company)
        {
            throw new NotImplementedException();
        }
    }
}

