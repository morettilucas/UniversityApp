using System.Collections.Generic;
using UniversityApp.DB;

namespace UniversityApp.Model.Services
{
    public interface IEstadoAcademicoRepository
    {
        IEnumerable<Curso> ObtenerCursosCicloLectivoActual(Alumno alumno);
        IEnumerable<Alumno> ObtenerAlumnosInscriptos(Asignatura asignatura);
        Curso ObtenerCurso(int id);
        int CrearCurso(Curso curso);
        void ActualizarCurso(Curso curso);
        void EliminarCurso(int id);
    }
}
