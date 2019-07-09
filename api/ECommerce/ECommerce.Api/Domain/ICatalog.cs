using System.Collections.Generic;
using System.Threading.Tasks;

namespace ECommerce.Api.Domain
{
    public interface ICatalog
    {
        Task<IEnumerable<Product>> GetAllProducts();
        Task<Product> GetProductWithId(int id);
        Task<IEnumerable<Product>> GetProductsFromCategory(string category);
    }
}
