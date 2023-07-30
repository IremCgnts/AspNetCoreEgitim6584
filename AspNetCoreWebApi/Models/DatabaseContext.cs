using Microsoft.EntityFrameworkCore;

namespace AspNetCoreWebApi.Models
{
    public class DatabaseContext : DbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<User> Users { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionBuilder)
        {
            optionBuilder.UseSqlServer(@"Server=.;database =WebApplication1;trusted_connection=true; TrustServerCertificate=True");
            base.OnConfiguring(optionBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // bu metod veritabanı tablolarının yapılandırılması, tablo oluştuktan sonra başlangıç kaydı oluşturulması gibi ayarlar için
            modelBuilder.Entity<Category>().Property(c => c.Name).HasMaxLength(50);
            modelBuilder.Entity<Product>().Property(c => c.Name).HasMaxLength(50);
            modelBuilder.Entity<Product>().Property(c => c.Image).HasMaxLength(100);
            modelBuilder.Entity<User>().Property(c => c.Name).HasMaxLength(50);
            modelBuilder.Entity<User>().Property(c => c.Surname).HasMaxLength(50);
            modelBuilder.Entity<User>().Property(c => c.Email).HasMaxLength(50);
            modelBuilder.Entity<User>().HasData(//HasData metodu db oluştuktan sonra db ye kayıt oluşturmak için data seed işlemi yapar
                new User
                {
                    Id = 1,
                    Email = "admin@aribilgi.co",
                    Name = "Admin",
                    Password = "1236"
                }
                );
            modelBuilder.Entity<Category>().HasData(
               new Category
               {
                   Id = 1,
                   Name = "Elektronik"
               },
            new Category
            {
                Id = 2,
                Name = "Bilgisayar"
            }
            );
            base.OnModelCreating(modelBuilder);

        }
    }
}
