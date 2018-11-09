using System.Collections.Generic;
using UniversityApp.DB;

namespace UniversityApp.Model.Repositories
{
    public interface IInscripcionesRepository
    {
        IEnumerable<Inscripcion> ObtenerInscripcionesPorFiltro(FiltroInscripciones filtro);
        void InscribirAlumno(Curso curso, Alumno alumno);
    }
}
