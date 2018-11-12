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
        [Column(Order = 1)]
        public int IDCurso { get; set; }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Column(Order = 2)]
        public int IDAsignatura { get; set; }

        public int? CupoMaximo { get; set; }

        [StringLength(100)] public string Docente { get; set; }

        public Asignatura Asignatura { get; set; }

        public virtual ICollection<Inscripcion> Inscripciones { get; set; }
    }
}