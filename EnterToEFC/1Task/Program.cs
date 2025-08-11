using System.Text;

namespace _1Task
{
    /*Завдання 1
    Розробіть консольну програму з використанням одного списку з типом (List< ваш вибір >) одного з варіантів.
    1. Магазин – Product
    1) + Id: Guid
    2) + Name: string
    3) + Cost: double
    4) + Description: string
    5) + Quantity: int
    Заповніть ваш список значеннями (10 значень).
    Виведіть на екран значення за індексом > 1, 5, 0, 7
    Знайдіть та виведіть індекси > 1, 5 за властивістю Id
    Знайдіть та виведіть індекси > 0, 7 за властивістю Name*/
    class Product
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

    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.Unicode;
            // Створюємо список продуктів із овочів
            List<Product> vegetables = new List<Product>
            {
                new Product { Id = Guid.NewGuid(), Name = "Tomato", Cost = 0.7, Description = "Red tomatoes", Quantity = 80 },
                new Product { Id = Guid.NewGuid(), Name = "Potato", Cost = 0.4, Description = "White potatoes", Quantity = 150 },
                new Product { Id = Guid.NewGuid(), Name = "Carrot", Cost = 0.3, Description = "Organic carrots", Quantity = 120 },
                new Product { Id = Guid.NewGuid(), Name = "Cucumber", Cost = 0.5, Description = "Fresh cucumbers", Quantity = 90 },
                new Product { Id = Guid.NewGuid(), Name = "Onion", Cost = 0.35, Description = "Yellow onions", Quantity = 100 },
                new Product { Id = Guid.NewGuid(), Name = "Pepper", Cost = 0.8, Description = "Bell peppers", Quantity = 60 },
                new Product { Id = Guid.NewGuid(), Name = "Garlic", Cost = 1.0, Description = "Fresh garlic cloves", Quantity = 40 },
                new Product { Id = Guid.NewGuid(), Name = "Broccoli", Cost = 1.5, Description = "Green broccoli", Quantity = 50 },
                new Product { Id = Guid.NewGuid(), Name = "Cauliflower", Cost = 1.4, Description = "White cauliflower", Quantity = 45 },
                new Product { Id = Guid.NewGuid(), Name = "Spinach", Cost = 1.2, Description = "Fresh spinach leaves", Quantity = 70 },
            };

            // Вивести елементи за індексами 1, 5, 0, 7
            Console.WriteLine("Вивід продуктів за індексами 1, 5, 0, 7:");
            int[] indicesToPrint = { 1, 5, 0, 7 };
            foreach (int i in indicesToPrint)
            {
                if (i >= 0 && i < vegetables.Count)
                {
                    Console.WriteLine($"Index {i}: {vegetables[i]}");
                }
            }

            // Знайти та вивести індекси 1, 5 за властивістю Id
            Console.WriteLine("\nЗнайти та вивести індекси 1, 5 за властивістю Id:");
            Guid id1 = vegetables[1].Id;
            Guid id5 = vegetables[5].Id;
            Console.WriteLine($"Index of product with Id {id1} = {vegetables.FindIndex(p => p.Id == id1)}");
            Console.WriteLine($"Index of product with Id {id5} = {vegetables.FindIndex(p => p.Id == id5)}");

            // Знайти та вивести індекси 0, 7 за властивістю Name
            Console.WriteLine("\nЗнайти та вивести індекси 0, 7 за властивістю Name:");
            string name0 = vegetables[0].Name;
            string name7 = vegetables[7].Name;
            Console.WriteLine($"Index of product with Name '{name0}' = {vegetables.FindIndex(p => p.Name == name0)}");
            Console.WriteLine($"Index of product with Name '{name7}' = {vegetables.FindIndex(p => p.Name == name7)}");
        }
    }
}
