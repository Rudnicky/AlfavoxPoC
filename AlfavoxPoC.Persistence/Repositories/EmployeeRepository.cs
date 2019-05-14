using AlfavoxPoC.Core.Domain;
using AlfavoxPoC.Core.Interfaces;

namespace AlfavoxPoC.Persistence.Repositories
{
    public sealed class EmployeeRepository : Repository<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(AlfavoxDbContext context) : base(context)
        {
        }
    }
}
