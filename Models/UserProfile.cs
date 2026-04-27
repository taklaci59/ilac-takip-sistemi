namespace ilactakipsistem.Models
{
    public class UserProfile
    {
        public int Id { get; set; }
        public string? UserName { get; set; }
        public bool IsOnboardingComplete { get; set; } = false;
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}
