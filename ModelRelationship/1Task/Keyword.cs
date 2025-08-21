namespace _1Task
{
    public class Keyword
    {
        public Guid KeywordId { get; set; }
        public string Name { get; set; }

        // Продукти з цим ключовим словом
        public ICollection<ProductKeyword> ProductKeywords { get; set; } = new List<ProductKeyword>();
    }
}
