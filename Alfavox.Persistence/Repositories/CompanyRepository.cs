using AlfavoxPoC.Core.Domain;

namespace Alfavox.Persistence.Repositories
{
    public sealed class CompanyRepository : Repository<Company>
    {
        public CompanyRepository(AlfavoxDbContext context) : base(context)
        {
        }
    }
}
