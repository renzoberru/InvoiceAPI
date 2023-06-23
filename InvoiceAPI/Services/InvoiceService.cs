using AutoMapper;
using DataBase.Models;
using InvoiceAPI.DTO;
using InvoiceAPI.Repositories;

namespace InvoiceAPI.Services
{
    public class InvoiceService : IInvoiceService
    {
        private readonly IInvoiceRepository _invoiceRepository;
        private readonly IMapper _mapper;
        public InvoiceService(IInvoiceRepository invoiceRepository, IMapper mapper)
        {
            _invoiceRepository = invoiceRepository;
            _mapper = mapper;
        }

        public List<InvoiceDTO> GetInvoices()
        {
            var invoices = _invoiceRepository.GetInvoices();            
            var invoicesDto = _mapper.Map<List<InvoiceDTO>>(invoices);
            var invoicesResponse = CalculateInvoiceTotals(invoicesDto);
            return invoicesResponse;
        }

        public List<InvoiceDTO> GetInvoicesByBuyerRut(double buyerRut)
        {
            var buyerInvoices = _invoiceRepository.GetInvoicesByBuyerRut(buyerRut);
            var buyerInvoicesDto = _mapper.Map<List<InvoiceDTO>>(buyerInvoices);
            var invoicesResponse = CalculateInvoiceTotals(buyerInvoicesDto);
            return invoicesResponse;
        }

        private static List<InvoiceDTO> CalculateInvoiceTotals(List<InvoiceDTO> invoices) 
        {            
            var invoicesResponse = invoices.Select(invoice =>
            {
                var invoiceTotal = invoice.InvoiceDetails.Sum(detail => detail.ProductTotal);
                invoice.InvoiceTotal = invoiceTotal;
                return invoice;
            }).OrderBy(i => i.DocumentNumber).ToList();
            return invoicesResponse;
        }        
    }
}
