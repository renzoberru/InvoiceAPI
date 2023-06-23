using System.Text.Json.Serialization;

namespace DataBase.Models
{
    public class InvoiceDetail
    {
        [JsonPropertyName("CantidadProducto")]
        public double ProductQuantity { get; set; }

        [JsonPropertyName("Producto")]
        public Product Product { get; set; }

        [JsonPropertyName("TotalProducto")]
        public double ProductTotal { get; set; }

    }
}
