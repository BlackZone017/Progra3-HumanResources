namespace RecursosH.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Licencia
    {
        public int id { get; set; }

        public int idEmpleado { get; set; }

        public DateTime? desde { get; set; }

        public DateTime? hasta { get; set; }

        [StringLength(100)]
        public string motivos { get; set; }

        [StringLength(100)]
        public string comentarios { get; set; }

        public virtual Empleado Empleado { get; set; }
    }
}
