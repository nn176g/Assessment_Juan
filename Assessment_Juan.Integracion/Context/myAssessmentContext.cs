using Microsoft.EntityFrameworkCore;
using Assessment_Juan.Model.Entities;

namespace Assessment_Juan.Integracion.Context
{
    public class myAssessmentContext : DbContext
    {
        //public myAssessmentContext()
        //{

        //}
        public myAssessmentContext(DbContextOptions<myAssessmentContext> options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }
        //entities
        public DbSet<Producto> Productos { get; set; }
        public DbSet<Compra> Compras { get; set; }
        public DbSet<Venta> Ventas { get; set; }
    }

}
