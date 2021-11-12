
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Assessment_Juan.Model.Entities
{
    public class Compra
    {
        [Key]
        public int Id { get; set; }
        public string FechaCompra { get; set; }
        public string Usuario { get; set; }
        public int Cantidad { get; set; }
        public int ProductoId { get; set; }
    }
}
