
using DataBase.Models;
using DataBase.Settings;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.VisualBasic.FileIO;
using System.Text.Json;

namespace DataBase
{
    public class JsonDbContext : IJsonDbContext
    {
        private readonly JsonFileSettings _jsonFileSettings;

        public JsonDbContext(IOptions<JsonFileSettings> options)
        {
            _jsonFileSettings = options.Value;             
        }

        public List<Invoice> GetInvoices() { 
            
            string jsonFilePath = _jsonFileSettings.JsonFilePath;

            string jsonString = File.ReadAllText(jsonFilePath);

            List<Invoice> Invoices = JsonSerializer.Deserialize<List<Invoice>>(jsonString);
            
            return Invoices;
        }
    }
}
