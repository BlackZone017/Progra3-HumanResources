namespace RecursosH.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Nomina")]
    public partial class Nomina
    {
        [Key]
        public int idNomina { get; set; }

        public int? año { get; set; }

        public string mes { get; set; }

        public decimal? montoTotal { get; set; }
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
