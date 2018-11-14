using System.Collections.Generic;
using UniversityApp.DB;

namespace UniversityApp.Model.Services
{
    public interface IAlumnosService
    {
        IEnumerable<Alumno> ObtenerAlumnos();
        Alumno ObtenerAlumno(int id);
        int CrearAlumno(Alumno alumno);
        void ActualizarAlumno(Alumno alumno);
        void EliminarAlumno(int id);
    }
}
