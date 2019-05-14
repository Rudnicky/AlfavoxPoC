using AlfavoxPoC.Core.Domain;
using AlfavoxPoC.Core.Interfaces;

namespace Alfavox.Persistence.Repositories
{
    public sealed class CompanyRepository : Repository<Company>, ICompanyRepository
    {
        public CompanyRepository(AlfavoxDbContext context) : base(context)
        {
        }
    }
}
