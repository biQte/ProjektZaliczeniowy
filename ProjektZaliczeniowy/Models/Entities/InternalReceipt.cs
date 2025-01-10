namespace ProjektZaliczeniowy.Models.Entities
{
    public class InternalReceipt
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string Remarks { get; set; }

        public ICollection<InternalReceiptDetail> Details { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }
    }
}
