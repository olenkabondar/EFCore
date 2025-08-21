namespace _1Task
{
    public class ProductKeyword
    {
        public Guid ProductId { get; set; }
        public Product Product { get; set; }

        public Guid KeywordId { get; set; }
        public Keyword Keyword { get; set; }
    }
}
