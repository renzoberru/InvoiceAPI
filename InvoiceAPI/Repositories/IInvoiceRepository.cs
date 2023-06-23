using DataBase.Models;

namespace InvoiceAPI.Repositories
{
    public interface IInvoiceRepository
    {
        public List<Invoice> GetInvoices();
        public List<Invoice> GetInvoicesByBuyerRut(double buyerRut);
    }
}
