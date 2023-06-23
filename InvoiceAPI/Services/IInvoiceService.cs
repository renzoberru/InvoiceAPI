using DataBase.Models;
using InvoiceAPI.DTO;

namespace InvoiceAPI.Services
{
    public interface IInvoiceService
    {
        public List<InvoiceDTO> GetInvoices();
        public List<InvoiceDTO> GetInvoicesByBuyerRut(double buyerRut);
    }
}
