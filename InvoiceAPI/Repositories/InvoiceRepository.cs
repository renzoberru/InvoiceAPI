using DataBase;
using DataBase.Models;

namespace InvoiceAPI.Repositories
{
    public class InvoiceRepository : IInvoiceRepository
    {
        private readonly IJsonDbContext _jsonDbContext;

        public InvoiceRepository(IJsonDbContext jsonDbContext)
        {
            _jsonDbContext = jsonDbContext;
        }

        public List<Invoice> GetInvoices()
        {
            var invoices = _jsonDbContext.GetInvoices();
            return invoices;
        }

        public List<Invoice> GetInvoicesByBuyerRut(double buyerRut)
        {
            var invoices = _jsonDbContext.GetInvoices();
            var buyerInvoices = invoices
                                .Where(i => i.BuyerRut == buyerRut)
                                .ToList();
            return buyerInvoices;
        }
    }
}
