using Microsoft.EntityFrameworkCore;
using System.Text;

namespace _1Task
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.Unicode;
            using (var context = new MyDatabaseContext())
            {
                // === Users with Products ===
                Console.WriteLine("User");
                foreach (var user in context.Users
                    .Include(u => u.UserProducts)
                        .ThenInclude(up => up.Product)
                            .ThenInclude(p => p.ProductKeywords)
                                .ThenInclude(pk => pk.Keyword))
                {
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine($"-{user.Name}");
                    foreach (var up in user.UserProducts)
                    {
                        var product = up.Product;
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Write($"--{product.Name} ( ");

                        Console.ForegroundColor = ConsoleColor.Green;
                        foreach (var pk in product.ProductKeywords)
                        {
                            Console.Write($"{pk.Keyword.Name} | ");
                        }
                        Console.WriteLine(")");
                    }
                }

                Console.WriteLine();

                // === Categories with Products ===
                Console.WriteLine("Category");
                foreach (var category in context.Categories
                    .Include(c => c.Products)
                        .ThenInclude(p => p.ProductKeywords)
                            .ThenInclude(pk => pk.Keyword))
                {
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine($"-{category.Name}");
                    foreach (var product in category.Products)
                    {
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Write($"--{product.Name} ( ");

                        Console.ForegroundColor = ConsoleColor.Green;
                        foreach (var pk in product.ProductKeywords)
                        {
                            Console.Write($"{pk.Keyword.Name} | ");
                        }
                        Console.WriteLine(")");
                    }
                }
                Console.ResetColor();
            }
        }
    }
}
