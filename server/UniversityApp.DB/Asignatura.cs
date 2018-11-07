namespace UniversityApp.DB
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Asignatura")]
    public class Asignatura
    {
        public Asignatura()
        {
            Cursos = new HashSet<Curso>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IDAsignatura { get; set; }

        [StringLength(100)]
        public string Nombre { get; set; }

        public virtual ICollection<Curso> Cursos { get; set; }
    }
}
