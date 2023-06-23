using System.Text.Json.Serialization;

namespace DataBase.Models
{
    public class Invoice
    {
        [JsonPropertyName("NumeroDocumento")]
        public double DocumentNumber { get; set; }

        [JsonPropertyName("RUTVendedor")]
        public double SellerRut { get; set; }

        [JsonPropertyName("DvVendedor")]
        public string SellerDV { get; set; }

        [JsonPropertyName("RUTComprador")]
        public double BuyerRut { get; set; }

        [JsonPropertyName("DvComprador")]
        public string BuyerDV { get; set; }

        [JsonPropertyName("DireccionComprador")]
        public string BuyerAddress { get; set; }

        [JsonPropertyName("ComunaComprador")]
        public double BuyerCommune { get; set; }

        [JsonPropertyName("RegionComprador")]
        public double BuyerRegion { get; set; }

        [JsonPropertyName("TotalFactura")]
        public double InvoiceTotal { get; set; }

        [JsonPropertyName("DetalleFactura")]
        public List<InvoiceDetail> InvoiceDetails { get; set; }
    }
}