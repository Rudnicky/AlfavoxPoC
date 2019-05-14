using AlfavoxPoC.Core.Domain;
using AlfavoxPoC.Core.Interfaces;

namespace AlfavoxPoC.Persistence.Repositories
{
    public sealed class CompanyLocationRepository : Repository<CompanyLocation>, ICompanyLocationRepository
    {
        public CompanyLocationRepository(AlfavoxDbContext context) : base(context)
        {
        }
    }
}
