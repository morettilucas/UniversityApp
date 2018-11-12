 namespace UniversityApp.DB
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Inscripciones")]
    public class Inscripcion
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int IDAlumno { get; set; }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int IDCurso { get; set; }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int IDAsignatura { get; set; }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Column(TypeName = "datetime2")]
        public DateTime FechaInscripcion { get; set; }

        [Required]
        public int Estado { get; set; }

        public virtual Alumno Alumno { get; set; }

        public virtual Curso Curso { get; set; }
    }
}