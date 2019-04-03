namespace RecursosH.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Permisos")]
    public partial class Permiso
    {
        public int id { get; set; }

        public int idEmpleado { get; set; }

        public DateTime? desde { get; set; }

        public DateTime? hasta { get; set; }

        [StringLength(200)]
        public string comentarios { get; set; }

        public virtual Empleado Empleado { get; set; }
    }
}
