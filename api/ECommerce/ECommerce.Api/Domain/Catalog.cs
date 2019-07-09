using System.Collections.Generic;
using System.Linq;

namespace ECommerce.Api.Domain
{
    public interface ICatalog
    {
        IEnumerable<Product> GetAllProducts();
        Product GetProductWithId(int id);
        IEnumerable<Product> GetProductsFromCategory(string category);
    }

    public class Catalog : ICatalog
    {
        private readonly IEnumerable<Product> products = new List<Product>
        {
            new Product(1, "Walden", 40.0m, "Description 1", Category.Books, 100),
            new Product(2, "A hundred years of solitude", 80.0m, "Description 3", Category.Books, 50),
            new Product(3, "iPhone 7", 2400.0m, "Description 2", Category.Eletronics, 100)
        };

        public IEnumerable<Product> GetAllProducts() => products;

        public Product GetProductWithId(int id) => products.FirstOrDefault(x => x.Id == id);

        public IEnumerable<Product> GetProductsFromCategory(string category) => products.Where(x => x.Category == category.ToCategory());
    }
}
