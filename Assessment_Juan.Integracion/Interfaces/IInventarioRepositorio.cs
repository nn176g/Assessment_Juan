using Assessment_Juan.Model.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Assessment_Juan.Integracion.Interfaces
{
    public interface IInventarioRepositorio
    {
        IEnumerable<Producto> GetListarProdcutos();
        Task<Producto> Add(Producto producto);
    }
}
