using System.Collections.Generic;
using UniversityApp.DB;

namespace UniversityApp.Model
{
    public class EstadoAcademico
    {
        public int IDAlumno { get; set; }
        public IEnumerable<Asignatura> AsignaturasPorCursar { get; set; }
        public IEnumerable<Asignatura> AsignaturasInscripto { get; set; }
        public IEnumerable<Asignatura> AsignaturasNoRegular { get; set; }
    }
}