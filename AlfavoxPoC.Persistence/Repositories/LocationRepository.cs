using AlfavoxPoC.Core.Domain;
using AlfavoxPoC.Core.Interfaces;

namespace AlfavoxPoC.Persistence.Repositories
{
    public sealed class LocationRepository : Repository<Location>, ILocationRepository
    {
        public LocationRepository(AlfavoxDbContext context) : base(context)
        {
        }
    }
}
