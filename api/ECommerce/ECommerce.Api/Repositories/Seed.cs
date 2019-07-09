using ECommerce.Api.Domain;
using System.Collections.Generic;
using System.Linq;

namespace ECommerce.Api.Repositories
{
    public class Seed
    {
        public static void SeedProducts(ECommerceContext context)
        {
            if (context.Products.Any())
                return;

            var products = new List<Product>
                {
                    new Product("Walden", 40m, "Description 1", Category.Books, 100),
                    new Product("A hundred years of solitude", 80m, "Description 3", Category.Books, 50),
                    new Product("iPhone 7", 2400m, "Description 2", Category.Eletronics, 100)
                };

            context.AddRange(products);
            context.SaveChanges();
        }
    }
}
