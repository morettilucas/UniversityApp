using System.Collections.Generic;

namespace UniversityApp.Api.Models
{
    public class AsignaturaDTO
    {
        public int IDAsignatura { get; set; }
        public string Nombre { get; set; }
        public IEnumerable<CursoDTO> Cursos { get; set; }
    }
}
