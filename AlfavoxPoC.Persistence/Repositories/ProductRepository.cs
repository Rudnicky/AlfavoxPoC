using AlfavoxPoC.Core.Domain;
using AlfavoxPoC.Core.Interfaces;

namespace AlfavoxPoC.Persistence.Repositories
{
    public sealed class ProductRepository : Repository<Product>, IProductRepository
    {
        public ProductRepository(AlfavoxDbContext context) : base(context)
        {
        }
    }
}
