namespace RecursosH.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=Modelo")
        {
        }

        public virtual DbSet<Cargo> Cargoes { get; set; }
        public virtual DbSet<Departamento> Departamentoes { get; set; }
        public virtual DbSet<Empleado> Empleadoes { get; set; }
        public virtual DbSet<Licencia> Licencias { get; set; }
        public virtual DbSet<Nomina> Nominas { get; set; }
        public virtual DbSet<Permiso> Permisos { get; set; }
        public virtual DbSet<Salida> Salidas { get; set; }
        public virtual DbSet<Vacacione> Vacaciones { get; set; }
        public virtual DbSet<EmpleadosActivo> EmpleadosActivos { get; set; }
        public virtual DbSet<EmpleadosInactivo> EmpleadosInactivos { get; set; }
        //public virtual DbSet<linq> { get; internal set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cargo>()
                .Property(e => e.codigoCargo)
                .IsUnicode(false);

            modelBuilder.Entity<Cargo>()
                .Property(e => e.cargo)
                .IsUnicode(false);

            modelBuilder.Entity<Cargo>()
                .HasMany(e => e.Empleadoes)
                .WithRequired(e => e.Cargo)
                .HasForeignKey(e => e.idCargo)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Departamento>()
                .Property(e => e.codigoDepartamento)
                .IsUnicode(false);

            modelBuilder.Entity<Departamento>()
                .Property(e => e.nombre)
                .IsUnicode(false);

            modelBuilder.Entity<Departamento>()
                .HasMany(e => e.Empleadoes)
                .WithRequired(e => e.Departamento)
                .HasForeignKey(e => e.idDepartamento)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Empleado>()
                .Property(e => e.codigoEmpleado)
                .IsUnicode(false);

            modelBuilder.Entity<Empleado>()
                .Property(e => e.nombre)
                .IsUnicode(false);

            modelBuilder.Entity<Empleado>()
                .Property(e => e.apellido)
                .IsUnicode(false);

            modelBuilder.Entity<Empleado>()
                .Property(e => e.telefono)
                .IsUnicode(false);

            modelBuilder.Entity<Empleado>()
                .Property(e => e.estatus).GetType();
                //.IsUnicode(false);

            modelBuilder.Entity<Empleado>()
                .HasMany(e => e.Licencias)
                .WithRequired(e => e.Empleado)
                .HasForeignKey(e => e.idEmpleado)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Empleado>()
                .HasMany(e => e.Permisos)
                .WithRequired(e => e.Empleado)
                .HasForeignKey(e => e.idEmpleado)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Empleado>()
                .HasMany(e => e.Salidas)
                .WithRequired(e => e.Empleado)
                .HasForeignKey(e => e.idEmpleado)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Empleado>()
                .HasMany(e => e.Vacaciones)
                .WithRequired(e => e.Empleado)
                .HasForeignKey(e => e.idEmpleado)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Licencia>()
                .Property(e => e.motivos)
                .IsUnicode(false);

            modelBuilder.Entity<Licencia>()
                .Property(e => e.comentarios)
                .IsUnicode(false);

            modelBuilder.Entity<Nomina>()
                .Property(e => e.montoTotal)
                .HasPrecision(11, 2);

            modelBuilder.Entity<Permiso>()
                .Property(e => e.comentarios)
                .IsUnicode(false);

            modelBuilder.Entity<Salida>()
                .Property(e => e.tipoSalida).GetType();
                //.IsUnicode(false);

            modelBuilder.Entity<Salida>()
                .Property(e => e.motivo)
                .IsUnicode(false);

            modelBuilder.Entity<Vacacione>()
                .Property(e => e.comentarios)
                .IsUnicode(false);

            modelBuilder.Entity<EmpleadosActivo>()
                .Property(e => e.codigoEmpleado)
                .IsUnicode(false);

            modelBuilder.Entity<EmpleadosActivo>()
                .Property(e => e.nombre)
                .IsUnicode(false);

            modelBuilder.Entity<EmpleadosActivo>()
                .Property(e => e.apellido)
                .IsUnicode(false);

            modelBuilder.Entity<EmpleadosActivo>()
                .Property(e => e.telefono)
                .IsUnicode(false);

            modelBuilder.Entity<EmpleadosActivo>()
                .Property(e => e.estatus)
                .IsUnicode(false);

            modelBuilder.Entity<EmpleadosInactivo>()
                .Property(e => e.codigoEmpleado)
                .IsUnicode(false);

            modelBuilder.Entity<EmpleadosInactivo>()
                .Property(e => e.nombre)
                .IsUnicode(false);

            modelBuilder.Entity<EmpleadosInactivo>()
                .Property(e => e.apellido)
                .IsUnicode(false);

            modelBuilder.Entity<EmpleadosInactivo>()
                .Property(e => e.telefono)
                .IsUnicode(false);

            modelBuilder.Entity<EmpleadosInactivo>()
                .Property(e => e.estatus)
                .IsUnicode(false);
        }
    }
}
