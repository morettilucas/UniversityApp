namespace UniversityApp.DB
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Inscripcion
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int IDAlumno { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int IDCurso { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime FechaInscripcion { get; set; }

        [Required]
        [StringLength(50)]
        public string Estado { get; set; }

        public virtual Alumno Alumno { get; set; }

        public virtual Curso Curso { get; set; }
    }
}
