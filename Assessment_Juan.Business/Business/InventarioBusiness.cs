using Assessment_Juan.Business.Interfaces;
using Assessment_Juan.Model.Entities;
using Assessment_Juan.Integracion.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Assessment_Juan.Business.Business
{
    public class InventarioBusiness :  IInventarioBusiness
    {
        public readonly IInventarioRepositorio _inventarioRepositorio;
        public InventarioBusiness(IInventarioRepositorio inventarioRepositorio)
        {
            _inventarioRepositorio = inventarioRepositorio;
        }
        public IEnumerable<Producto> GetListarProductos()
        {
            return _inventarioRepositorio.GetListarProdcutos();
        }

        public async Task<Producto> Insert(Producto model)
        {
            return await _inventarioRepositorio.Add(model);
        }
    }
}

