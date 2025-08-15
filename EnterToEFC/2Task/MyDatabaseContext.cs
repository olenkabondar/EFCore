using Microsoft.EntityFrameworkCore;

namespace _2Task
{
    internal class MyDatabaseContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        //public DbSet<Error> Errors { get; set; } // додали, але проігноруємо в OnModelCreating
        
        //Зберігатимемо помилки лише в пам'яті
        public List<Error> Errors { get; } = new List<Error>();


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //рядок підключення до локальної SQL Server бази
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=MyEFDB;Trusted_Connection=True;");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Складовий ключ для Product
            modelBuilder.Entity<Product>()
                .HasKey(p => new { p.ProductId, p.ProductAlterId });

            // Обмеження на строкові поля
            modelBuilder.Entity<Product>()
                .Property(p => p.Name)
                .HasMaxLength(50)
                .IsRequired();

            modelBuilder.Entity<Product>()
                .Property(p => p.Description)
                .HasMaxLength(200);

            // Налаштування числового поля
            modelBuilder.Entity<Product>()
                .Property(p => p.Cost)
                .HasColumnType("decimal(10,2)");

            // Ігнорування типу Error (щоб таблиця не створювалася)
            modelBuilder.Ignore<Error>();
        }
    }
}
