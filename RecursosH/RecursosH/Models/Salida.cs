namespace RecursosH.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Salida")]
    public partial class Salida
    {
        public int id { get; set; }

        public int idEmpleado { get; set; }

        public string tipoSalida { get; set; }

        [StringLength(100)]
        public string motivo { get; set; }

        public DateTime? fechaSalida { get; set; }

        public virtual Empleado Empleado { get; set; }
    }

    public enum TipoSalida
    {
        Renuncia,
        Despido,
        Deshaucio
    }
}
