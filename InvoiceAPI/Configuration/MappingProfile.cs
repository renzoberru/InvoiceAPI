using AutoMapper;
using DataBase.Models;
using InvoiceAPI.DTO;

namespace InvoiceAPI.Configuration
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Invoice, InvoiceDTO>();
            CreateMap<InvoiceDetail,InvoiceDetailDTO>();
            CreateMap<Product, ProductDTO>();
        }
    }
}
