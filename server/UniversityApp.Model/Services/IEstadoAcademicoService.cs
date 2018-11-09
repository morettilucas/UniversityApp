using System.Collections.Generic;
using UniversityApp.DB;

namespace UniversityApp.Model.Services
{
    public interface IEstadoAcademicoService
    {
        IEnumerable<Curso> ObtenerEstadoAcademicoPorAlumno(int id);
    }
}
