using InvoiceAPI.DTO;

namespace InvoiceAPI.Services
{
    public interface IBuyerService
    {
        public List<BuyerAmountDTO> GetBuyerAmountsTotals();
        public FrequentBuyerDTO GetFrequentBuyer();
    }
}
