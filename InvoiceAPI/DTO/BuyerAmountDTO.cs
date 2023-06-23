namespace InvoiceAPI.DTO
{
    public class BuyerAmountDTO : IBuyerDTO
    {
        public int BuyerRut { get; set; }

        public string BuyerDV { get; set; }

        public double AmountPurchases { get; set; }
    }
}
