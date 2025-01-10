namespace ProjektZaliczeniowy.Models.Entities
{
    public class ExternalReceipt
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string Remarks { get; set; }

        public ICollection<ExternalReceiptDetail> Details { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }
    }
}
