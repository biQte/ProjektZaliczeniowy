namespace ProjektZaliczeniowy.Models.Entities
{
    public class InternalIssueDetail
    {
        public int Id { get; set; }
        public int InternalIssueId { get; set; }
        public int ProductId { get; set; }
        public decimal Quantity { get; set; }

        public InternalIssue InternalIssue { get; set; }
        public Product Product { get; set; }
    }
}
