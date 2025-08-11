using System.Text;

namespace _2Task
{
    /*Завдання 2
    Використовуючи Visual Studio, створіть проєкт за шаблоном Console Application. 
    Потрібно: Інсталюйте необхідні пакети для роботи з Entity Framework Створіть контекст бази даних MyDatabaseContext та, 
    використовуючи матеріали завдання 1 (цього уроку), перенесіть ваш список у якості колекції DbSet, виконайте міграцію Заповніть таким самим способом,
    що і в першому завдані, через контекст MyDatabaseContext вашу колекцію тими самими значеннями. Переконайтесь, що дані збереглись у базу. 
    Знайти та вивести > 1, 5, 0, 7 з Product/User/Order (ваш варінт) контексту за ім’ям*/
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.Unicode;
            using (var context = new MyDatabaseContext())
            {
                if (!context.Products.Any())
                {
                    var products = new[]
                    {
                    new Product { Id = Guid.NewGuid(), Name = "Помідор", Cost = 15.5, Description = "Соковитий", Quantity = 100 },
                    new Product { Id = Guid.NewGuid(), Name = "Огірок", Cost = 10, Description = "Свіжий", Quantity = 200 },
                    new Product { Id = Guid.NewGuid(), Name = "Морква", Cost = 12, Description = "Корисна", Quantity = 150 },
                    new Product { Id = Guid.NewGuid(), Name = "Капуста", Cost = 8.5, Description = "Зелена", Quantity = 120 },
                    new Product { Id = Guid.NewGuid(), Name = "Буряк", Cost = 9, Description = "Смачний", Quantity = 180 },
                    new Product { Id = Guid.NewGuid(), Name = "Редиска", Cost = 7, Description = "Гостра", Quantity = 160 },
                    new Product { Id = Guid.NewGuid(), Name = "Цибуля", Cost = 6, Description = "Ароматна", Quantity = 140 },
                    new Product { Id = Guid.NewGuid(), Name = "Часник", Cost = 20, Description = "Корисний", Quantity = 130 },
                    new Product { Id = Guid.NewGuid(), Name = "Перець", Cost = 18, Description = "Гострий", Quantity = 110 },
                    new Product { Id = Guid.NewGuid(), Name = "Кабачок", Cost = 11, Description = "М’який", Quantity = 170 }
                };

                    context.Products.AddRange(products);
                    context.SaveChanges();
                }

                // Вивести продукти за індексами 1, 5, 0, 7 за ім’ям (Name)
                var productsList = context.Products.OrderBy(p => p.Name).ToList();

                int[] indices = { 1, 5, 0, 7 };

                foreach (var i in indices)
                {
                    if (i < productsList.Count)
                        Console.WriteLine($"Index {i}: {productsList[i]}");
                }
            }
        }
    }
    public class Product
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public double Cost { get; set; }
        public string Description { get; set; }
        public int Quantity { get; set; }

        public override string ToString()
        {
            return $"Id={Id}, Name={Name}, Cost={Cost}, Description={Description}, Quantity={Quantity}";
        }
    }
}
