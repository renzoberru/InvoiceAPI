using AutoMapper;
using InvoiceAPI.DTO;
using InvoiceAPI.Repositories;

namespace InvoiceAPI.Services
{
    public class BuyerService : IBuyerService
    {
        private readonly IInvoiceRepository _invoiceRepository;
        private readonly IMapper _mapper;
        public BuyerService(IInvoiceRepository invoiceRepository, IMapper mapper)
        {
            _invoiceRepository = invoiceRepository;
            _mapper = mapper;
        }

        public List<BuyerAmountDTO> GetBuyerAmountsTotals()
        {
            var invoices = _invoiceRepository.GetInvoices();
            var invoicesDto = _mapper.Map<List<InvoiceDTO>>(invoices);
            var buyersAmount = invoicesDto.GroupBy(invoice => new
            {
                invoice.BuyerRut,
                invoice.BuyerDV,
            })
                                    .Select(group => new BuyerAmountDTO
                                    {
                                        BuyerRut = group.Key.BuyerRut,
                                        BuyerDV = group.Key.BuyerDV,
                                        AmountPurchases = group.Sum(g => g.InvoiceDetails.Sum(dt => dt.ProductTotal))
                                    })
                                    .OrderBy(b => b.BuyerRut).ToList();
            return buyersAmount;
        }

        public FrequentBuyerDTO GetFrequentBuyer()
        {
            var invoices = _invoiceRepository.GetInvoices();
            var invoicesDto = _mapper.Map<List<InvoiceDTO>>(invoices);

            var frequentBuyer = invoicesDto.GroupBy(invoice => new
            {
                invoice.BuyerRut,
                invoice.BuyerDV
            })
                                        .Select(group => new FrequentBuyerDTO
                                        {
                                            BuyerRut = group.Key.BuyerRut,
                                            BuyerDV = group.Key.BuyerDV,
                                            QuantityPurchases = group.Count()
                                        })
                                        .OrderByDescending(o => o.QuantityPurchases)
                                        .FirstOrDefault();
            return frequentBuyer;
        }
    }
}
