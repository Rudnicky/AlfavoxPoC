using AlfavoxPoC.Core.Domain;
using AlfavoxPoC.Core.Interfaces;

namespace Alfavox.Persistence.Repositories
{
    public sealed class ProductRepository : Repository<Product>, IProductRepository
    {
        public ProductRepository(AlfavoxDbContext context) : base(context)
        {
        }
    }
}
