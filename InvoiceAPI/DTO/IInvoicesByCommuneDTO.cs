namespace InvoiceAPI.DTO
{
    public interface IInvoicesByCommuneDTO
    {
        public Dictionary<int,List<InvoiceDTO>> InvoicesByCommune { get; set; }
    }
}
