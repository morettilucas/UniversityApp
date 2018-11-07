
using System.Collections.Generic;
using UniversityApp.DB;

namespace UniversityApp.Model.Repositories
{
    public interface IAlumnosRepository
    {
        IEnumerable<Alumno> ObtenerAlumnos();
        Alumno ObtenerAlumno(int id);
        int CrearAlumno(Alumno alumno);
        void ActualizarAlumno(Alumno alumno);
        void EliminarAlumno(int id);
    }
}
