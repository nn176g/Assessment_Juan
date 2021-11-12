using Assessment_Juan.Integracion.Context;
using Assessment_Juan.Integracion.Interfaces;
using Assessment_Juan.Model.Entities;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assessment_Juan.Integracion.Repositorio
{
    public class VentaRepositorio : IVentaRepositorio
    {
        private readonly myAssessmentContext _myAssessmentContext;
        public readonly ILogger<VentaRepositorio> _logger;

        public VentaRepositorio(ILogger<VentaRepositorio> logger, myAssessmentContext myAssessmentContext)
        {
            _myAssessmentContext = myAssessmentContext;
            _logger = logger;
        }

        public IEnumerable<Venta> GetListarVentas()
        {
            var result = _myAssessmentContext.Ventas.ToList();
            return result;
        }

        public async Task<Venta> Add(Venta venta)
        {
            _logger.LogInformation("Attempting Insert a Record in the Venta Table");
            _myAssessmentContext.Ventas.Add(venta);
            _logger.LogInformation("Insert Venta method successful");
            await _myAssessmentContext.SaveChangesAsync();
            return venta;
        }
    }
}
