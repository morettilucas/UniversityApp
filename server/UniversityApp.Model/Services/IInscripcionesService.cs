using System.Collections.Generic;
using UniversityApp.DB;

namespace UniversityApp.Model.Services
{
    public interface IInscripcionesService
    {
        IEnumerable<Inscripcion> ObtenerInscripciones(FiltroInscripciones filtro);
        IEnumerable<Curso> ObtenerCursosHabilitadosParaInscripcionPorAlumno(int id, CicloLectivo cicloLectivo);
        void InscribirAlumno(int asignaturaId, int cursoId, int alumnoId);
    }
}