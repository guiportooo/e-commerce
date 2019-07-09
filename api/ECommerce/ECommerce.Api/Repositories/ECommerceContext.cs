using ECommerce.Api.Domain;
using ECommerce.Api.Repositories.Configurations;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Api.Repositories
{
    public class ECommerceContext : DbContext
    {
        public DbSet<Product> Products { get; set; }

        public ECommerceContext(DbContextOptions<ECommerceContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ProductConfiguration());
        }
    }
}
