using InvoiceAPI.DTO;
using InvoiceAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InvoiceAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvoiceController : ControllerBase
    {
        private readonly IInvoiceService _invoiceService;
        public InvoiceController(IInvoiceService invoiceService)
        {
            _invoiceService = invoiceService;
        }

        // GET: api/Invoice/Invoices
        /// <summary>
        /// Obtiene el listado completo de las facturas.
        /// </summary>
        /// <remarks>
        /// Devuelve el listado completo de las facturas registradas en JsonEjemplo.json.
        /// </remarks>        
        /// <response code="401">Unauthorized. No se ha indicado o es incorrecto la ApiKey.</response>              
        /// <response code="200">OK. Devuelve la lista de facturas.</response>        
        /// <response code="404">NotFound. No se ha encontrado el objeto solicitado.</response>
        [HttpGet("Invoices")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public ActionResult<List<InvoiceDTO>> Invoices()
        {
            var invoices = _invoiceService.GetInvoices();
            if (invoices == null) 
            { 
                return NotFound();
            }
            return Ok(invoices);
        }

        // GET: api/Invoice
        /// <summary>
        /// Obtiene el listado de las facturas de un comprador
        /// </summary>
        /// <remarks>
        /// Devuelve el listado de todas las facturas registradas en JsonEjemplo.json, que estén asociadas al Rut del Comprador
        /// </remarks>
        /// <param name="buyerRut">Rut del Comprador</param>
        /// <response code="401">Unauthorized. No se ha indicado o es incorrecto la ApiKey.</response>              
        /// <response code="200">OK. Devuelve la lista de facturas del comprador.</response>        
        /// <response code="404">NotFound. No se ha encontrado el objeto solicitado.</response>
        [HttpGet("{buyerRut}")]
        public ActionResult<List<InvoiceDTO>> InvoicesByBuyerRut(double buyerRut)
        {
            var buyerInvoices = _invoiceService.GetInvoicesByBuyerRut(buyerRut);
            if (buyerInvoices == null)
            {
                return NotFound();
            }
            return Ok(buyerInvoices);
        }
    }
}
