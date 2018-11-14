using System.Collections.Generic;
using UniversityApp.DB;

namespace UniversityApp.Api.Models
{
    public class EstadoAcademicoDTO
    {
        public int IDAlumno { get; set; }
        public IEnumerable<AsignaturaDTO> AsignaturasPorCursar { get; set; }
        public IEnumerable<AsignaturaDTO> AsignaturasInscripto { get; set; }
        public IEnumerable<AsignaturaDTO> AsignaturasNoRegular { get; set; }
    }
}