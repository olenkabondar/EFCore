namespace _1Task
{
    public class Product
    {
        public Guid ProductId { get; set; }
        public string Name { get; set; }
        public double Cost { get; set; }
        public string Description { get; set; }
        public int Quantity { get; set; }

        // Навігаційна властивість для зв'язку багато-до-багатьох з User
        public ICollection<UserProduct> UserProducts { get; set; } = new List<UserProduct>();

        // Навігаційна властивість для зв'язку багато-до-багатьох з Keyword
        public ICollection<ProductKeyword> ProductKeywords { get; set; } = new List<ProductKeyword>();

        // Опціонально: зв'язок з категорією
        public Guid CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
