namespace GimnasioFenix.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Web.Mvc;

    [Table("Alumno")]
    public partial class Alumno
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Nombre { get; set; }

        [DisplayName("Número de socio")]
        [Column("Numero de socio")]
        [Required]
        [StringLength(50)]
        public string Numero_de_socio { get; set; }

        [Required]
        [StringLength(50)]
        public string Direccion { get; set; }

        [Required]
        [StringLength(50)]
        public string Localidad { get; set; }

        [Required]
        [StringLength(50)]
        public string Telefono { get; set; }

        [DisplayName("Ingreso")]
        [Column("Fecha de ingreso")]
        [Required]
        [StringLength(50)]
        public string Fecha_de_ingreso { get; set; }

        public int Reservas { get; set; }

        public int IdActividad { get; set; }

        public virtual Actividad Actividad { get; set; }
    }
}
