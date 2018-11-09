using System;

namespace UniversityApp.Api.Models
{
    public class InscripcionDTO
    {
        public DateTime FechaInscripcion { get; set; }

        public string Estado { get; set; }

        public virtual AlumnoDTO Alumno { get; set; }

        public virtual CursoDTO Curso { get; set; }
    }
}
