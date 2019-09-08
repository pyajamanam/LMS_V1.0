using LMS.App.Core.Data.Entities;
using System.Collections.Generic;

namespace LMS.App.Core.Data.Repositories
{
    public interface ICountryRepository
    {
        List<Country> GeCountries();
        bool Add(Country company);
        bool Delete(int companyId);
        Company Edit(int compid);
        bool Update(Country company);
        void Dispose();
    }
}
