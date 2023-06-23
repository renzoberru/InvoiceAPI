using System.Text.Json.Serialization;

namespace DataBase.Models
{
    public class Product
    {
        [JsonPropertyName("Descripcion")]
        public string Description { get; set; }

        [JsonPropertyName("Valor")]
        public double Value { get; set; }
    }
}
