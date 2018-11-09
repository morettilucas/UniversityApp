using System;
using System.Collections.Generic;
using System.Linq;
using UniversityApp.DB;
using UniversityApp.Model;
using UniversityApp.Model.Services;

namespace UniversityApp.Services
{
    public class InscripcionesService : IInscripcionesService
    {
        public IUnitOfWork Context { get; set; }

        public InscripcionesService(IUnitOfWork context)
        {
            Context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public IEnumerable<Inscripcion> ObtenerInscripciones(FiltroInscripciones filtro)
        {
            return Context.InscripcionesRepository.ObtenerInscripcionesPorFiltro(filtro);
        }

        public IEnumerable<Curso> CursosHabilitadosParaInscripcionPorAlumno(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Alumno> ObtenerAlumnosInscriptosPorCurso(Curso curso)
        {
            throw new NotImplementedException();
        }

        public void InscribirAlumno(Curso curso, Alumno alumno)
        {
            var asignatura = Context.AsignaturasRepository.ObtenerAsignatura(curso.IDAsignatura);
            if(asignatura == null || asignatura.Cursos.All(c => c.IDCurso != curso.IDCurso)) throw new Exception($"No existe el curso {curso.IDCurso}");

            var filtro = new FiltroInscripciones
            {
                IdAlumno = alumno.IDAlumno
            };
            var inscripcionesAlumno = Context.InscripcionesRepository.ObtenerInscripcionesPorFiltro(filtro);

            if(inscripcionesAlumno.All(i => i.Curso.IDCurso != curso.IDCurso && i.Estado != EstadoInscripcion.Inscripto))
                throw new Exception("El alumno ya se encuentra inscripto en el curso");

            Context.InscripcionesRepository.InscribirAlumno(curso, alumno);
            Context.Commit();
        }
    }
}
