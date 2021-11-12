using Assessment_Juan.Integracion.Interfaces;
using Assessment_Juan.Integracion.Context;
using Assessment_Juan.Model.Entities;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace Assessment_Juan.Integracion.Repositorio
{
    public class InventarioRepositorio : IInventarioRepositorio
    {
        public readonly myAssessmentContext _myAssessmentContext;
        public readonly ILogger<InventarioRepositorio> _logger;
        public InventarioRepositorio(ILogger<InventarioRepositorio> logger, myAssessmentContext myAssessmentContext)
        {
            _myAssessmentContext = myAssessmentContext;
            _logger = logger;
        }

        public IEnumerable<Producto> GetListarProdcutos()
        {
            var result = _myAssessmentContext.Productos.ToList();
            return result;
        }

        public async Task<Producto> Add(Producto producto)
        {
            _logger.LogInformation("Attempting Insert a Record in the Prducto Table");
            _myAssessmentContext.Productos.Add(producto);
            _logger.LogInformation("Insert Producto method successful");
            await _myAssessmentContext.SaveChangesAsync();
            return producto;
        }
    }
}