using Assessment_Juan.Integracion.Context;
using Assessment_Juan.Integracion.Interfaces;
using Assessment_Juan.Model.Entities;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assessment_Juan.Integracion.Repositorio
{
    public class CompraRepositorio : ICompraRepositorio
    {
        public readonly myAssessmentContext _myAssessmentContext;
        public readonly ILogger<CompraRepositorio> _logger;
        public CompraRepositorio(ILogger<CompraRepositorio> logger, myAssessmentContext myAssessmentContext)
        {
            _myAssessmentContext = myAssessmentContext;
            _logger = logger;
        }
        public IEnumerable<Compra> GetListarCompras()
        {
            var result = _myAssessmentContext.Compras.ToList();
            return result;
        }

        public async Task<Compra> Add(Compra compra)
        {
            _logger.LogInformation("Attempting Insert a Record in the Compra Table");
            _myAssessmentContext.Compras.Add(compra);
            _logger.LogInformation("Insert Compra method successful");
            await _myAssessmentContext.SaveChangesAsync();
            return compra;
        }
    }
}
