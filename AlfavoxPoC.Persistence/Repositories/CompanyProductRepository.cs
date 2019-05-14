using AlfavoxPoC.Core.Domain;
using AlfavoxPoC.Core.Interfaces;

namespace AlfavoxPoC.Persistence.Repositories
{
    public sealed class CompanyProductRepository : Repository<CompanyProduct>, ICompanyProductRepository
    {
        public CompanyProductRepository(AlfavoxDbContext context) : base(context)
        {
        }
    }
}
