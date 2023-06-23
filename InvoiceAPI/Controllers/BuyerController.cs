using InvoiceAPI.DTO;
using InvoiceAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InvoiceAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BuyerController : ControllerBase
    {
        private readonly IBuyerService _buyerService;

        public BuyerController(IBuyerService buyerService)
        {
            _buyerService = buyerService;
        }


        // GET: api/Buyer/FrequentBuyer
        /// <summary>
        /// Obtiene al Comprador Frecuente.
        /// </summary>
        /// <remarks>
        /// Devuelve al comprador que tiene asociado más facturas (compras) registradas en JsonEjemplo.json.
        /// </remarks>
        /// <response code="401">Unauthorized. No se ha indicado o es incorrecto la ApiKey.</response>              
        /// <response code="200">OK. Devuelve al comprador frecuente.</response>
        /// <response code="204">NoContent. La solicitud se ha completado con éxito, pero sin contenido.</response>
        /// <response code="404">NotFound. No se ha encontrado el objeto solicitado.</response>
        [HttpGet("FrequentBuyer")]
        public ActionResult<FrequentBuyerDTO> FrequentBuyer()
        {
            var frequentBuyer = _buyerService.GetFrequentBuyer();
            if (frequentBuyer == null)
            {
                return NotFound();
            }
            return Ok(frequentBuyer);
        }

        // GET: api/Buyer/AmountPurchasesByBuyers
        /// <summary>
        /// Obtiene el listado de compradores y sus respectivos montos de compras.
        /// </summary>
        /// <remarks>
        /// Devuelve al comprador que tiene asociado más facturas (compras) registradas en JsonEjemplo.json.
        /// </remarks>
        /// <response code="401">Unauthorized. No se ha indicado o es incorrecto la ApiKey.</response>              
        /// <response code="200">OK. Devuelve el listado de compradores con sus respectivos totales de compras.</response>        
        /// <response code="404">NotFound. No se ha encontrado el objeto solicitado.</response>
        [HttpGet("AmountPurchasesByBuyers")]
        public ActionResult<List<BuyerAmountDTO>> AmountPurchasesByBuyers()
        {
            var buyersAmount = _buyerService.GetBuyerAmountsTotals();
            if (buyersAmount == null)
            {
                return NotFound();
            }
            return Ok(buyersAmount);
        }
    }
}
