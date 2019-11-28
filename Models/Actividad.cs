namespace GimnasioFenix.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Actividad")]
    public partial class Actividad
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Actividad()
        {
            Alumno = new HashSet<Alumno>();
        }

        public int Id { get; set; }
        [DisplayName ("Actividad")]
        [Column("Actividad")]
        [Required]
        [StringLength(50)]
        public string Actividad1 { get; set; }

        public int Estado { get; set; }

        public int Cupos { get; set; }

        public int IdDia { get; set; }

        public int IdHorario { get; set; }

        public int IdProfesor { get; set; }

        public virtual Dia Dia { get; set; }

        public virtual Horario Horario { get; set; }

        public virtual Profesor Profesor { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Alumno> Alumno { get; set; }
    }
}
