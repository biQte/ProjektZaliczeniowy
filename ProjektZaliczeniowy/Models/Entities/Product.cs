namespace ProjektZaliczeniowy.Models.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string WarehouseLocation { get; set; }
        public string CatalogNumber { get; set; }
        public string Ean { get; set; }
        public string UnitOfMeasure { get; set; }
        public string ProductType { get; set; }
        public decimal QuantityInStock { get; set; }

        public ICollection<ExternalReceiptDetail> ExternalReceiptDetails { get; set; }
        public ICollection<InternalReceiptDetail> InternalReceiptDetails { get; set; }
        public ICollection<InternalIssueDetail> InternalIssueDetails { get; set; }
        public ICollection<ExternalIssueDetail> ExternalIssueDetails { get; set; }
    }
}
