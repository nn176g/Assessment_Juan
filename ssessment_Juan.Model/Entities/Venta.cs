using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Assessment_Juan.Model.Entities
{
    public class Venta
    {
        [Key]
        public int Id { get; set; }
        public string Fecha { get; set; }
        public string Usuario { get; set; }
        public string Cantidad { get; set; }
        public int ProductoId { get; set; }
    }
}
