namespace ProjektZaliczeniowy.Models.Entities
{
    public class ExternalIssueDetail
    {
        public int Id { get; set; }
        public int ExternalIssueId { get; set; }
        public int ProductId { get; set; }
        public decimal Quantity { get; set; }

        public ExternalIssue ExternalIssue { get; set; }
        public Product Product { get; set; }
    }
}
