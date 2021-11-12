using Assessment_Juan.Business.Interfaces;
using Assessment_Juan.Model.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace Assessment_Juan.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VentaController : ControllerBase
    {
        private readonly IVentaBusiness _ventaBusiness;
        private readonly ILogger<VentaController> _logger;

        public VentaController(ILogger<VentaController> logger, IVentaBusiness ventaBusiness)
        {
            _logger = logger;
            _ventaBusiness = ventaBusiness;
        }
        [HttpGet]
        [Route("Listar")]
        public IActionResult GetListarVentas()
        {
            try
            {
                return Ok(_ventaBusiness.GetListarVentas());
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                throw e;
            }

        }

        [HttpPost]
        [Route("InsertarVenta")]
        public async Task<IActionResult> InsertVenta(Venta model)
        {
            try
            {
                return Ok(await _ventaBusiness.Insert(model));
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                throw e;
            }
        }
    }
}
