using System.Text.Json.Serialization;

namespace InvoiceAPI.DTO
{
    public interface IInvoiceDTO
    {
        public int SellerRut { get; set; }

        public string SellerDV { get; set; }

        public int BuyerRut { get; set; }

        public string BuyerDV { get; set; }

        public string BuyerAddress { get; set; }

        public int BuyerCommune { get; set; }

        public int BuyerRegion { get; set; }

        public double InvoiceTotal { get; set; }
    }
}
