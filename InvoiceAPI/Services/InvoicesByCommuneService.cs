using AutoMapper;
using InvoiceAPI.DTO;
using InvoiceAPI.Repositories;

namespace InvoiceAPI.Services
{
    public class InvoicesByCommuneService : IInvoicesByCommuneService
    {
        private readonly IInvoiceRepository _invoiceRepository;
        private readonly IMapper _mapper;

        public InvoicesByCommuneService(IInvoiceRepository invoiceRepository, IMapper mapper)
        {
            _invoiceRepository = invoiceRepository;
            _mapper = mapper;
        }

        public InvoicesByCommuneDTO GetInvoicesGroupByCommune()
        {
            var invoices = _invoiceRepository.GetInvoices();
            var invoicesDto = _mapper.Map<List<InvoiceDTO>>(invoices);
            var groupedInvoices = invoicesDto.GroupBy(invoice => invoice.BuyerCommune)
                                .ToDictionary(g => g.Key, g => g.ToList()
                                );
            var invoicesByCommuneDTO = new InvoicesByCommuneDTO
            {
                InvoicesByCommune = groupedInvoices
            };
            return invoicesByCommuneDTO;
        }
    }
}
