using Microsoft.EntityFrameworkCore;

namespace _1Task
{
    public class MyDatabaseContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Keyword> Keywords { get; set; }
        public DbSet<ProductKeyword> ProductKeywords { get; set; }
        public DbSet<UserProduct> UserProducts { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=MyEFDB2;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // User
            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(u => u.UserId);
                entity.Property(u => u.Name).HasMaxLength(50);
                entity.Property(u => u.LastName).HasMaxLength(50);
                entity.Property(u => u.Login).HasMaxLength(20);
                entity.Property(u => u.Password).HasMaxLength(100);
                entity.Property(u => u.Email).HasMaxLength(100);
            });

            // Product
            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasKey(p => p.ProductId);
                entity.Property(p => p.Name).HasMaxLength(50);
                entity.Property(p => p.Description).HasMaxLength(200);
            });

            // Category
            modelBuilder.Entity<Category>(entity =>
            {
                entity.HasKey(c => c.CategoryId);
                entity.Property(c => c.Name).HasMaxLength(50);
            });

            // Keyword
            modelBuilder.Entity<Keyword>(entity =>
            {
                entity.HasKey(k => k.KeywordId);
                entity.Property(k => k.Name).HasMaxLength(50);
            });

            // Проміжна таблиця UserProduct (багато-до-багатьох)
            modelBuilder.Entity<UserProduct>()
                .HasKey(up => new { up.UserId, up.ProductId });

            modelBuilder.Entity<UserProduct>()
                .HasOne(up => up.User)
                .WithMany(u => u.UserProducts)
                .HasForeignKey(up => up.UserId);

            modelBuilder.Entity<UserProduct>()
                .HasOne(up => up.Product)
                .WithMany(p => p.UserProducts)
                .HasForeignKey(up => up.ProductId);

            // Проміжна таблиця ProductKeyword (багато-до-багатьох)
            modelBuilder.Entity<ProductKeyword>()
                .HasKey(pk => new { pk.ProductId, pk.KeywordId });

            modelBuilder.Entity<ProductKeyword>()
                .HasOne(pk => pk.Product)
                .WithMany(p => p.ProductKeywords)
                .HasForeignKey(pk => pk.ProductId);

            modelBuilder.Entity<ProductKeyword>()
                .HasOne(pk => pk.Keyword)
                .WithMany(k => k.ProductKeywords)
                .HasForeignKey(pk => pk.KeywordId);
        }
    }
}
