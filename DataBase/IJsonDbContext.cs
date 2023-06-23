using DataBase.Models;

namespace DataBase
{
    public interface IJsonDbContext
    {
        List<Invoice> GetInvoices();
    }
}
