namespace RecursosH.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Entrada
    {
        public int id { get; set; }

        [StringLength(6)]
        public string codigoEmpleado { get; set; }

        [StringLength(41)]
        public string Empleado { get; set; }

        [Column("Fecha Entrada")]
        [StringLength(12)]
        public string Fecha_Entrada { get; set; }
    }

    public enum Meses
    {
        January,
        February,
        March,
        April,
        May,
        June,
        July,
        August,
        September,
        October,
        November,
        December
    }
}
