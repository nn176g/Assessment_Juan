using Assessment_Juan.Business.Interfaces;
using Assessment_Juan.Model.Entities;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assessment_Juan.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class InventarioController : ControllerBase  
    {
        private readonly IInventarioBusiness _inventarioBusiness;
        private readonly ILogger<InventarioController> _logger;
        public InventarioController(ILogger<InventarioController> logger, IInventarioBusiness inventarioBusiness)
        {
            _logger = logger;
            _inventarioBusiness = inventarioBusiness;
        }

        [HttpGet]
        //[EnableCors("ListarProductos")]
        [Route("Listar")]
        public IActionResult GetListarProdcutos()
        {
            try
            {
                return Ok(_inventarioBusiness.GetListarProductos());
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                throw e;
            }
        }

        [HttpPost]
        //[EnableCors("InsertarProducto")]
        [Route("InsertarProducto")]
        public async Task<IActionResult> InsertInventario(Producto model)
        {
            try
            {
                var bdy = Request;
                //string body = Request.ContentLength. Request.c.Content.ReadAsStringAsync().Result;
                return Ok(await _inventarioBusiness.Insert(model));
            }
            catch (Exception e)
            {

                _logger.LogError(e.Message);
                throw e;
            }
        }
    }
}
