using Microsoft.EntityFrameworkCore;

namespace _2Task
{
    internal class MyDatabaseContext : DbContext
    {
        public DbSet<Product> Products { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //рядок підключення до локальної SQL Server бази
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=MyEFDB;Trusted_Connection=True;");
        }
    }
}
