using System.Collections.Generic;
using UniversityApp.DB;

namespace UniversityApp.Model.Services
{
    public interface IAsignaturasService
    {
        IEnumerable<Asignatura> ObtenerAsignaturas();
        Asignatura ObtenerAsignaturaPorId(int id);
        IEnumerable<Alumno> ObtenerAlumnosRecursantesPorAsignatura(Asignatura asignatura);
    }
}
