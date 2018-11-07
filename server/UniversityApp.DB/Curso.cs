namespace UniversityApp.DB
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Cursos")]
    public class Curso
    {
        public Curso()
        {
            Inscripciones = new HashSet<Inscripcion>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IDCurso { get; set; }

        public int IDAsignatura { get; set; }

        public Asignatura Asignatura { get; set; }

        public int? CupoMaximo { get; set; }

        [StringLength(100)]
        public string Docente { get; set; }

        public virtual ICollection<Inscripcion> Inscripciones { get; set; }
    }
}
