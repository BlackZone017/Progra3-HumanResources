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

        [Required(ErrorMessage = "El campo Codigo de Empleado no puede estar vacio")]
        [StringLength(6)]
        public string codigoEmpleado { get; set; }

        [Required(ErrorMessage = "El campo Nombre de Empleado no puede estar vacio")]
        [StringLength(20)]
        public string nombre { get; set; }

        [Required(ErrorMessage = "El campo Apellido de Empleado no puede estar vacio")]
        [StringLength(20)]
        public string apellido { get; set; }

        [Required(ErrorMessage = "El campo Telefono de Empleado no puede estar vacio")]
        [StringLength(15)]
        public string telefono { get; set; }

        [Required(ErrorMessage = "El campo Id del Departamento de Empleado no puede estar vacio")]
        public int idDepartamento { get; set; }

        [Required(ErrorMessage = "El campo Id Cargo de Empleado no puede estar vacio")]
        public int idCargo { get; set; }

        [Required(ErrorMessage = "El campo Fecha de Ingreso de Empleado no puede estar vacio")]
        public DateTime? fechaIngreso { get; set; }

        [Required(ErrorMessage = "El campo Salario de Empleado no puede estar vacio")]
        public decimal? salario { get; set; }

        [Required(ErrorMessage = "El campo Estatus de Empleado no puede estar vacio")]
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
