using AlfavoxPoC.Core.Domain;
using AlfavoxPoC.Core.Interfaces;
using System.Linq;

namespace AlfavoxPoC.Persistence.Repositories
{
    public sealed class CompanyLocationRepository : Repository<CompanyLocation>, ICompanyLocationRepository
    {
        private readonly AlfavoxDbContext _context;

        public CompanyLocationRepository(AlfavoxDbContext context) : base(context)
        {
            _context = context;
        }

        public IQueryable<CompanyLocation> GetQueryable()
        {
            return _context.CompanyLocation;
        }
    }
}
