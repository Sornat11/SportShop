using SportShop.Models.DbModels;
using System.Data.Entity;
using System.Linq;
using System.Web;


namespace SportShop.Models
{
    public class SportShopContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Order>()
                .HasRequired(z => z.Customer)
                .WithMany()
                .HasForeignKey(z => z.CustomerID);

            modelBuilder.Entity<Order>()
                .HasRequired(z => z.Product)
                .WithMany()
                .HasForeignKey(z => z.ProductID);

            base.OnModelCreating(modelBuilder);
        }
    }
}