namespace TestAPI.Models
{
    public class Profile
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Role { get; set; }
        public int Score { get; set; } = 0;
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
