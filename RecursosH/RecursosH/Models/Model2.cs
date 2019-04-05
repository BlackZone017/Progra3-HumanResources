namespace RecursosH.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Model2 : DbContext
    {
        public Model2()
            : base("name=Model2")
        {
        }

        public virtual DbSet<CantSalida> CantSalidas { get; set; }
        public virtual DbSet<Entrada> Entradas { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CantSalida>()
                .Property(e => e.Empleado)
                .IsUnicode(false);

            modelBuilder.Entity<CantSalida>()
                .Property(e => e.Fecha_Entrada)
                .IsUnicode(false);

            modelBuilder.Entity<Entrada>()
                .Property(e => e.codigoEmpleado)
                .IsUnicode(false);

            modelBuilder.Entity<Entrada>()
                .Property(e => e.Empleado)
                .IsUnicode(false);

            modelBuilder.Entity<Entrada>()
                .Property(e => e.Fecha_Entrada)
                .IsUnicode(false);
        }
    }
}
