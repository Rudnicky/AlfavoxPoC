using AlfavoxPoC.Core.Domain;

namespace Alfavox.Persistence.Repositories
{
    public sealed class EmployeeRepository : Repository<Employee>
    {
        public EmployeeRepository(AlfavoxDbContext context) : base(context)
        {
        }
    }
}
