using InsuranceCompany_api.Data.Entity;
using Microsoft.EntityFrameworkCore;

namespace InsuranceCompany_api.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<UserProduct> UserProducts { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>()
                .HasMany(user => user.userProductColl)
                .WithOne(userProduct => userProduct.User)
                .HasForeignKey(userProduct => userProduct.UserId);

            modelBuilder.Entity<Product>()
                .HasMany(product => product.userProductColl)
                .WithOne(userProduct => userProduct.Product)
                .HasForeignKey(userProduct => userProduct.ProductId);

            modelBuilder.Entity<UserProduct>()
                .HasKey(userProduct => new { userProduct.UserId, userProduct.ProductId });

        }
    }
}
