using InvoiceAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InvoiceAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvoicesByCommuneController : ControllerBase
    {
        private readonly IInvoicesByCommuneService _invoicesByCommuneService;

        public InvoicesByCommuneController(IInvoicesByCommuneService invoicesByCommuneService)
        {
            _invoicesByCommuneService = invoicesByCommuneService;
        }

        // GET: api/InvoiceByCommune/InvoicesGroupByCommune
        /// <summary>
        /// Obtiene el listado de facturas agrupadas por Comuna.
        /// </summary>
        /// <remarks>
        /// Devuelve el listado de facturas registradas en JsonEjemplo.json, agrupadas por la comuna de comprador.
        /// </remarks>
        /// <response code="401">Unauthorized. No se ha indicado o es incorrecto la ApiKey.</response>              
        /// <response code="200">OK. Devuelve el listado de facturas agrupadas por comuna.</response>
        /// <response code="204">NoContent. La solicitud se ha completado con éxito, pero sin contenido.</response>
        /// <response code="404">NotFound. No se ha encontrado el objeto solicitado.</response>
        [HttpGet]
        public ActionResult<InvoicesByCommuneService> InvoicesGroupByCommune()
        {
            var invoiceResponse = _invoicesByCommuneService.GetInvoicesGroupByCommune();
            if (invoiceResponse == null)
            { 
                return NotFound();
            }            
            return Ok(invoiceResponse);
        }
    }
}
