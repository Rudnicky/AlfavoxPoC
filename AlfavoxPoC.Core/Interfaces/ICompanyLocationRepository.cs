using AlfavoxPoC.Core.Domain;
using AlfavoxPoC.Core.Repositories;
using System.Linq;

namespace AlfavoxPoC.Core.Interfaces
{
    public interface ICompanyLocationRepository : IRepository<CompanyLocation>
    {
        IQueryable<CompanyLocation> GetQueryable();
    }
}
