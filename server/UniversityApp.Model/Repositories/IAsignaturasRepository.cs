using System.Collections.Generic;
using UniversityApp.DB;

namespace UniversityApp.Model.Repositories
{
    public interface IAsignaturasRepository
    {
        IEnumerable<Asignatura> ObtenerAsignaturas();
        Asignatura ObtenerAsignatura(int id);
    }
}
