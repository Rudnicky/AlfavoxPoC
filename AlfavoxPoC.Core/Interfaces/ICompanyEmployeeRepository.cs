using AlfavoxPoC.Core.Domain;
using AlfavoxPoC.Core.Repositories;
using System.Linq;

namespace AlfavoxPoC.Core.Interfaces
{
    public interface ICompanyEmployeeRepository : IRepository<CompanyEmployee>
    {
        IQueryable<CompanyEmployee> GetQueryable();
    }
}
