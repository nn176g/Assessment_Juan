using Assessment_Juan.Business.Interfaces;
using Assessment_Juan.Integracion.Interfaces;
using Assessment_Juan.Model.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Assessment_Juan.Business.Business
{
    public class CompraBusiness : ICompraBusiness
    {
        public readonly ICompraRepositorio _comprasRepositorio;
        public CompraBusiness(ICompraRepositorio comprasRepositorio)
        {
            _comprasRepositorio = comprasRepositorio;
        }

        public IEnumerable<Compra> GetListarCompras()
        {
            return _comprasRepositorio.GetListarCompras();
        }

        public async Task<Compra> Insert(Compra model)
        {
            return await _comprasRepositorio.Add(model);
        }
    }
}
