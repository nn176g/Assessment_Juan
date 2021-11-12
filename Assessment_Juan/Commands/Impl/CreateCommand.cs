using Assessment_Juan.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assessment_Juan.Impl
{
    public class CreateCommand : ICommand
    {
        public Compra Inventario { get; set; }
    }
}
