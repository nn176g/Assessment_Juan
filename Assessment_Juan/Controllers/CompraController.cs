using Assessment_Juan.Business.Interfaces;
using Assessment_Juan.Commands.Handlers;
using Assessment_Juan.Impl;
using Assessment_Juan.Model.Entities;
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
    public class CompraController : ControllerBase
    {
        private readonly ICompraBusiness _compraBusiness;
        private readonly ILogger<CompraController> _logger;
        private readonly IHandler<CreateCommand> _handler;

        public CompraController(ILogger<CompraController> logger, ICompraBusiness compraBusiness, IHandler<CreateCommand> handler)
        {
            _logger = logger;
            _compraBusiness = compraBusiness;
            _handler = handler;
        }

        [HttpGet]
        [Route("Listar")]
        public IActionResult GetListarCompras()
        {
            try
            {
                return Ok(_compraBusiness.GetListarCompras());
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                throw e;
            }

        }

        [HttpPost]
        [Route("InsertarCompra")]
        public async Task<IActionResult> InsertCompra(CreateCommand model)
        {
            try
            {
                await _handler.Execute(model);
                return Ok();
                //var respuesta = await _compraBusiness.Insert(model);
                //if(respuesta != null)
                //{
                //    await _handler.Execute(model);
                //    return Ok(respuesta);
                //}
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                throw e;
            }
        }

    }
}
