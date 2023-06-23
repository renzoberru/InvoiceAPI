namespace InvoiceAPI.DTO
{
    public class InvoicesByCommuneDTO : IInvoicesByCommuneDTO
    {
        public Dictionary<int, List<InvoiceDTO>> InvoicesByCommune { get; set; }
    }
}
