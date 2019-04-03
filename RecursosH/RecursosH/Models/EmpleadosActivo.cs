namespace RecursosH.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("EmpleadosActivos")]
    public partial class EmpleadosActivo
    {
        [Key]
        [Column(Order = 0)]
        public int id { get; set; }

        [StringLength(6)]
        public string codigoEmpleado { get; set; }

        [StringLength(20)]
        public string nombre { get; set; }

        [StringLength(20)]
        public string apellido { get; set; }

        [StringLength(15)]
        public string telefono { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int idDepartamento { get; set; }

        [Key]
        [Column(Order = 2)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int idCargo { get; set; }

        public DateTime? fechaIngreso { get; set; }

        public int? salario { get; set; }

        [StringLength(10)]
        public string estatus { get; set; }

        public int? idManager { get; set; }
    }
}
