using ECommerce.Api.Domain;
using ECommerce.Api.Extensions;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce.Api.Repositories
{
    public class CatalogRepository : ICatalog
    {
        private readonly ECommerceContext context;

        public CatalogRepository(ECommerceContext context) => this.context = context;

        public async Task<IEnumerable<Product>> GetAllProducts() => await context.Products.ToListAsync();

        public async Task<Product> GetProductWithId(int id) => await context.Products.FindAsync(id);

        public async Task<IEnumerable<Product>> GetProductsFromCategory(string category)
            => await context.Products.Where(x => x.Category == category.ToCategory()).ToListAsync();
    }
}
