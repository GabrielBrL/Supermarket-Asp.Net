using CoreBusiness;
using Microsoft.EntityFrameworkCore;

namespace Plugins.DataStore.SQL
{
    public class MarketContext : DbContext
    {
        public MarketContext(DbContextOptions<MarketContext> options) : base(options)
        {
        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Transaction> Transactions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Category>()
                .HasMany(c => c.Products)
                .WithOne(p => p.Category)
                .HasForeignKey(p => p.CategoryId);
            modelBuilder.Entity<Category>()
                .HasData(
                new Category { CategoryId = 1, Name = "Categoria1", Description = "Categoria teste" },
                new Category { CategoryId = 2, Name = "Categoria2", Description = "Categoria teste" },
                new Category { CategoryId = 3, Name = "Categoria3", Description = "Categoria teste" }
            );
            modelBuilder.Entity<Product>()
                .HasData(
                new Product()
                {
                    ProductId = 1,
                    CategoryId = 1,
                    Name = "Test",
                    Price = 15.59,
                    Quantity = 100
                },
                new Product()
                {
                    ProductId = 2,
                    CategoryId = 3,
                    Name = "Test1",
                    Price = 15.59,
                    Quantity = 100
                },
                new Product()
                {
                    ProductId = 3,
                    CategoryId = 2,
                    Name = "Test3",
                    Price = 15.59,
                    Quantity = 100
                });
        }
    }
}