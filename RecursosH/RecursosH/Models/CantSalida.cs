namespace RecursosH.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class CantSalida
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int id { get; set; }

        [StringLength(41)]
        public string Empleado { get; set; }

        [Column("Fecha Entrada")]
        [StringLength(12)]
        public string Fecha_Entrada { get; set; }
    }
}
