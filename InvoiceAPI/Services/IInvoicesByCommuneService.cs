using InvoiceAPI.DTO;

namespace InvoiceAPI.Services
{
    public interface IInvoicesByCommuneService
    {
        public InvoicesByCommuneDTO GetInvoicesGroupByCommune();
    }
}
