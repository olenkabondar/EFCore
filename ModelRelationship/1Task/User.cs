namespace _1Task
{
    public class User
    {
        public Guid UserId { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }

        // Навігаційна властивість для зв'язку багато-до-багатьох з Product
        public ICollection<UserProduct> UserProducts { get; set; } = new List<UserProduct>();
    }
}
