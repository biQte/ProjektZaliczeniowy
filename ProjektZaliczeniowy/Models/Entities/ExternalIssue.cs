namespace ProjektZaliczeniowy.Models.Entities
{
    public class ExternalIssue
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string Remarks { get; set; }

        public ICollection<ExternalIssueDetail> Details { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }
    }
}
