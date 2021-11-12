using Assessment_Juan.Model.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Assessment_Juan.Business.Interfaces
{
    public interface IVentaBusiness
    {
        IEnumerable<Venta> GetListarVentas();
        Task<Venta> Insert(Venta model);
    }
}
