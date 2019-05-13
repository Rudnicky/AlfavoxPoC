using AlfavoxPoC.Core.Domain;

namespace Alfavox.Persistence.Repositories
{
    public sealed class LocationRepository : Repository<Location>
    {
        public LocationRepository(AlfavoxDbContext context) : base(context)
        {
        }
    }
}
