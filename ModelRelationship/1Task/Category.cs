namespace _1Task
{
    public class Category
    {
        public Guid CategoryId { get; set; }
        public string Name { get; set; }

        // Продукти цієї категорії
        public ICollection<Product> Products { get; set; } = new List<Product>();
    }
}
