namespace InvoiceAPI.DTO
{
    public class InvoiceDetailDTO
    {
        public double ProductQuantity { get; set; }

        public ProductDTO Product { get; set; }

        public double ProductTotal { get; set; }
    }
}
