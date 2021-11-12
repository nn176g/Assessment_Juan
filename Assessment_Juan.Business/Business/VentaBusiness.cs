using Assessment_Juan.Business.Interfaces;
using Assessment_Juan.Integracion.Interfaces;
using Assessment_Juan.Model.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Assessment_Juan.Business.Business
{
    public class VentaBusiness : IVentaBusiness
    {
        public readonly IVentaRepositorio _ventaRepositorio;
        public VentaBusiness(IVentaRepositorio ventaRepositorio)
        {
            _ventaRepositorio = ventaRepositorio;
        }

        public IEnumerable<Venta> GetListarVentas()
        {
            return _ventaRepositorio.GetListarVentas();
        }

        public async Task<Venta> Insert(Venta model)
        {
            return await _ventaRepositorio.Add(model);
        }
    }
}
