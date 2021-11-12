using Assessment_Juan.Model.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Assessment_Juan.Integracion.Interfaces
{
    public interface ICompraRepositorio
    {
        IEnumerable<Compra> GetListarCompras();
        Task<Compra> Add(Compra compra);
    }
}
