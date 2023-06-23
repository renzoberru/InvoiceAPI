namespace InvoiceAPI.DTO
{
    public class FrequentBuyerDTO : IBuyerDTO
    {
        public int BuyerRut { get; set; }
        public string BuyerDV { get; set; }
        public int QuantityPurchases { get; set; }
    }
}
