namespace _2Task
{
    public class Product
    {
        public Guid ProductId { get; set; }
        public int ProductAlterId { get; set; }

        public string Name { get; set; }
        public double Cost { get; set; }
        public string Description { get; set; }
        public int Quantity { get; set; }

        public override string ToString()
        {
            return $"Id={ProductId}, Name={Name}, Cost={Cost}, Description={Description}, Quantity={Quantity}";
        }

    }
}
