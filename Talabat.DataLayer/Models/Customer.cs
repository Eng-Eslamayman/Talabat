namespace Talabat.DataLayer.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public ICollection<Order> Orders { get; set; }
    }
}
