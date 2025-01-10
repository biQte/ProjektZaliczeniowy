namespace ProjektZaliczeniowy.Models.Entities
{
    public class InternalReceiptDetail
    {
        public int Id { get; set; }
        public int InternalReceiptId { get; set; }
        public int ProductId { get; set; }
        public decimal Quantity { get; set; }

        public InternalReceipt InternalReceipt { get; set; }
        public Product Product { get; set; }
    }
}
