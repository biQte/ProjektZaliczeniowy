namespace ProjektZaliczeniowy.Models.Entities
{
    public class ExternalReceiptDetail
    {
        public int Id { get; set; }
        public int ExternalReceiptId { get; set; }
        public int ProductId { get; set; }
        public decimal Quantity { get; set; }

        public ExternalReceipt ExternalReceipt { get; set; }
        public Product Product { get; set; }
    }
}
