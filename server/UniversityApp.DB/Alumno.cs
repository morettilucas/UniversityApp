namespace UniversityApp.DB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Alumnos")]
    public class Alumno
    {
        public Alumno()
        {
            Inscripciones = new HashSet<Inscripcion>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IDAlumno { get; set; }

        [Required]
        [StringLength(100)]
        public string Nombre { get; set; }

        [Required]
        [StringLength(20)]
        public string Legajo { get; set; }

        public int? Edad { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? FechaNacimiento { get; set; }

        public virtual ICollection<Inscripcion> Inscripciones { get; set; }
    }
}
