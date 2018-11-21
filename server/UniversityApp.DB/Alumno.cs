namespace UniversityApp.DB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Alumnos")]
    public partial class Alumno
    {
        public Alumno()
        {
            Inscripciones = new HashSet<Inscripcion>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IDAlumno { get; set; }

        [Required] [StringLength(100)] public string Nombre { get; set; }

        [Required] [StringLength(20)] public string Legajo { get; set; }

        public int? Edad
        {
            get
            {
                if (FechaNacimiento == null) return null;
                var age = DateTime.Now.Year - FechaNacimiento.Value.Year;
                if (FechaNacimiento > DateTime.Now.AddYears(-age)) age--;
                return age;
            }
        }

        [Column(TypeName = "datetime2")] public DateTime? FechaNacimiento { get; set; }

        public virtual ICollection<Inscripcion> Inscripciones { get; set; }
    }
}