namespace RecursosH.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Empleado")]
    public partial class Empleado
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Empleado()
        {
            Licencias = new HashSet<Licencia>();
            Permisos = new HashSet<Permiso>();
            Salidas = new HashSet<Salida>();
            Vacaciones = new HashSet<Vacacione>();
        }

        public int id { get; set; }

        [StringLength(6)]
        public string codigoEmpleado { get; set; }

        [StringLength(20)]
        public string nombre { get; set; }

        [StringLength(20)]
        public string apellido { get; set; }

        [StringLength(15)]
        public string telefono { get; set; }

        public int idDepartamento { get; set; }

        public int idCargo { get; set; }

        public DateTime? fechaIngreso { get; set; }

        public int? salario { get; set; }

        [StringLength(10)]
        public string estatus { get; set; }

        public int? idManager { get; set; }

        public virtual Cargo Cargo { get; set; }

        public virtual Departamento Departamento { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Licencia> Licencias { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Permiso> Permisos { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Salida> Salidas { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Vacacione> Vacaciones { get; set; }
    }

    public enum Estatus
    {
        Activo,
        Inactivo
    }
}
