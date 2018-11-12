using System;

namespace UniversityApp.Api.Models
{
    public class InscripcionDTO
    {
        public DateTime FechaInscripcion { get; set; }

        public string Estado { get; set; }

        public AlumnoDTO Alumno { get; set; }

        public CursoDTO Curso { get; set; }
    }
}
