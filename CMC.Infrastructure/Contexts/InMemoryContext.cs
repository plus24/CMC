using CMC.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;

namespace CMC.Infrastructure.Contexts
{
    public class InMemoryContext : DbContext
    {
        public DbSet<Product> Products => Set<Product>();
        public DbSet<CurrencyRate> CurrencyRates => Set<CurrencyRate>();
        public DbSet<ShippingCost> ShippingCosts => Set<ShippingCost>();

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase("InMemoryDb");

            base.OnConfiguring(optionsBuilder);
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>()
                        .HasData(
                            new List<Product>
                            {
                                new Product { Id = 1, Name = "Headset", Price = 42, Image="https://images.unsplash.com/photo-1505740420928-5e560c06d30e?ixlib=rb-1.2.1&ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&auto=format&fit=crop&w=2370&q=80" },
                                new Product { Id = 2, Name = "Samsung Galaxy Watch", Price =  399.99, Image="https://images.unsplash.com/photo-1523275335684-37898b6baf30?ixlib=rb-1.2.1&ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&auto=format&fit=crop&w=2198&q=80"},
                                new Product { Id = 3, Name = "Product X", Price = 5},
                                new Product { Id = 4, Name = "Polaroid Camera", Price = 30, Image="https://images.unsplash.com/photo-1526170375885-4d8ecf77b99f?ixlib=rb-1.2.1&ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&auto=format&fit=crop&w=2370&q=80" },
                                new Product { Id = 5, Name = "Product Y", Price = 8 },
                                new Product { Id = 6, Name = "Rayban Glass", Price = 69.99, Image="https://images.unsplash.com/photo-1572635196237-14b3f281503f?ixlib=rb-1.2.1&ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&auto=format&fit=crop&w=1480&q=80" },
                                new Product { Id = 7, Name = "Nike Shoes", Price = 200, Image="https://images.unsplash.com/photo-1491553895911-0055eca6402d?ixlib=rb-1.2.1&ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&auto=format&fit=crop&w=1480&q=80" },
                                new Product { Id = 8, Name = "Lipstick", Price = 15, Image="https://images.unsplash.com/photo-1586495777744-4413f21062fa?ixlib=rb-1.2.1&ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&auto=format&fit=crop&w=1015&q=80" },
                                new Product { Id = 9, Name = "Nike shoe 2", Price = 120, Image="https://images.unsplash.com/photo-1542291026-7eec264c27ff?ixlib=rb-1.2.1&ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&auto=format&fit=crop&w=2370&q=80" },
                                new Product { Id = 10, Name = "Pepsi", Price = 4, Image="https://images.unsplash.com/photo-1553456558-aff63285bdd1?ixlib=rb-1.2.1&ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&auto=format&fit=crop&w=987&q=80" },
                                new Product { Id = 11, Name = "Product 11", Price = 4218.4 },
                                new Product { Id = 12, Name = "Product 12", Price = 1248.3 },
                                new Product { Id = 13, Name = "Product 13", Price = 5334.6 },
                            }
                        );

            modelBuilder.Entity<CurrencyRate>()
            .HasData(
                new List<CurrencyRate>
                {
                                new CurrencyRate { Id = 1, SourceCurrency = "AUD", TargetCurrency = "USD", Rate=0.7},
                                new CurrencyRate { Id = 2, SourceCurrency = "AUD", TargetCurrency = "EUR", Rate=0.5}
                }
            );

            modelBuilder.Entity<ShippingCost>()
            .HasData(
                new List<ShippingCost>
                {
                                new ShippingCost { Id = 1, Name = "Uner 50", Threshold = 50, Price=10},
                                new ShippingCost { Id = 2, Name = "Over 50", Price=20},
                }
            );


            base.OnModelCreating(modelBuilder);
        }
    }
}
