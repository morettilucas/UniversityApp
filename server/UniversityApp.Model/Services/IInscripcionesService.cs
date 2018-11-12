using System.Collections.Generic;
using UniversityApp.DB;

namespace UniversityApp.Model.Services
{
    public interface IInscripcionesService
    {
        IEnumerable<Inscripcion> ObtenerInscripciones(FiltroInscripciones filtro);
        IEnumerable<Curso> CursosHabilitadosParaInscripcionPorAlumno(int id);
        IEnumerable<Alumno> ObtenerAlumnosInscriptosPorCurso(Curso curso);
        void InscribirAlumno(int asignaturaId, int cursoId, int alumnoId);
    }
}
