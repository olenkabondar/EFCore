using System.Text;

namespace _2Task
{
    /* Завдання 2  (1 урок)
        Використовуючи Visual Studio, створіть проєкт за шаблоном Console Application. 
        Потрібно: Інсталюйте необхідні пакети для роботи з Entity Framework Створіть контекст бази даних MyDatabaseContext та, 
        використовуючи матеріали завдання 1 (цього уроку), перенесіть ваш список у якості колекції DbSet, виконайте міграцію Заповніть таким самим способом,
        що і в першому завдані, через контекст MyDatabaseContext вашу колекцію тими самими значеннями. Переконайтесь, що дані збереглись у базу. 
        Знайти та вивести > 1, 5, 0, 7 з Product/User/Order (ваш варінт) контексту за ім’ям

    Завдання 1 (2 урок)
        Потрібно:
        Обмежити всі строкові властивості (обмеження підбирати, виходячи з призначення поля) через DataAnnotations.
        Змінити назву Id на – (НазваКласу)Id.
        Для полів з типом DateTime вказати тип Date через DataAnnotations Внести всі зміни у базу.

     Завдання 2 (2 урок)
        Створити новий перелічуваний тип StatusCode зі значенями:
        1) Ok = 200
        2) NotFound = 404
        3) Server = 500
        Створити новий клас Error де є:
        1) + Message: string
        2) + Time: DateTime
        3) + Request: string
        4) + Status: StatusCode.
        Додати у клас контексту MyDatabaseContext нову колекцію DbSet з типом Error.
        Додати до існуючої колекції додаткове поле (НазваКласу)AlterId, налаштувати через Fluent API цю властивість таким чином, щоб у базі це був складовий ключ.
        Налаштувати через Fluent API ігнорування типу Error та внести зміни у базу Створити конструкцію обробки виключень і у блок catch при невдалому зчитуванні з бази у контексті заповнювати колекцію Error (для перевірки спробуйте отримати від’ємний індекс).
        Якщо все правильно, то Ви будете заповнювати колекцію з помилками при невірному запиті, але сама таблиця у базі буде відсутня.
     
     Завдання 3*
        Продовжуйте завданя 2 (цього уроку).Спробуйте налаштувати все без застосування DataAnnotations.*/
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.Unicode;
            using (var context = new MyDatabaseContext())
            {
                try
                {
                    // Вивести продукти за індексами 1, 5, 0, 7 за ім’ям (Name)
                    var productsList = context.Products.OrderBy(p => p.Name).ToList();

                    int[] indices = { 1, 5, 0, 7 };

                    foreach (var i in indices)
                    {
                        if (i < productsList.Count)
                            Console.WriteLine($"Index {i}: {productsList[i]}");
                    }


                    // Пробуємо отримати елемент з від'ємним індексом
                    var product = context.Products.Skip(-1).First();
                }
                catch (Exception ex)
                {
                    var error = new Error
                    {
                        Message = ex.Message,
                        Time = DateTime.Now,
                        Request = "Skip(-1).First()",
                        Status = StatusCode.Server
                    };

                    // Просто зберігаємо в пам'яті
                    Console.WriteLine($"Помилка: {error.Message}");
                }
            }       
        }
    }
}
