namespace ProjektZaliczeniowy.Models.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string PasswordHash { get; set; }
        public string Role { get; set; }
        public bool IsActive { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime? LastLogin { get; set; }

        public ICollection<ExternalIssue> ExternalIssues { get; set; }
        public ICollection<ExternalReceipt> ExternalReceipts { get; set; }
        public ICollection<InternalIssue> InternalIssues { get; set; }
        public ICollection<InternalReceipt> InternalReceipts { get; set; }
    }
}
