using AlfavoxPoC.Core.Domain;
using AlfavoxPoC.Core.Interfaces;
using System.Linq;

namespace AlfavoxPoC.Persistence.Repositories
{
    public sealed class CompanyEmployeeRepository : Repository<CompanyEmployee>, ICompanyEmployeeRepository
    {
        private readonly AlfavoxDbContext _context;

        public CompanyEmployeeRepository(AlfavoxDbContext context) 
            : base(context)
        {
            _context = context;
        }

        public IQueryable<CompanyEmployee> GetQueryable()
        {
            return _context.CompanyEmployee;
        }
    }
}
