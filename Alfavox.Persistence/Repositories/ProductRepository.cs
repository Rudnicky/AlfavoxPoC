using AlfavoxPoC.Core.Domain;

namespace Alfavox.Persistence.Repositories
{
    public sealed class ProductRepository : Repository<Product>
    {
        public ProductRepository(AlfavoxDbContext context) : base(context)
        {
        }
    }
}
