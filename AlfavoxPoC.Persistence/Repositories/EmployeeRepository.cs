using AlfavoxPoC.Core.Domain;
using AlfavoxPoC.Core.Interfaces;
using AlfavoxPoC.Persistence;

namespace AlfavoxPoC.Persistence.Repositories
{
    public sealed class EmployeeRepository : Repository<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(AlfavoxDbContext context) : base(context)
        {
        }
    }
}
