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
        public IAsignaturasService AsignaturasService { get; set; }

        public InscripcionesService(IUnitOfWork context, IAsignaturasService asignaturasService)
        {
            Context = context ?? throw new ArgumentNullException(nameof(context));
            AsignaturasService = asignaturasService ?? throw new ArgumentNullException(nameof(asignaturasService));
        }

        public IEnumerable<Inscripcion> ObtenerInscripciones(FiltroInscripciones filtro)
        {
            return Context.InscripcionesRepository.ObtenerInscripcionesPorFiltro(filtro);
        }

        public IEnumerable<Curso> ObtenerCursosHabilitadosParaInscripcionPorAlumno(int id, CicloLectivo cicloLectivo)
        {
            var cursosLibres = AsignaturasService.ObtenerCursosLibres(cicloLectivo);
            var filtro = new FiltroInscripciones
            {
                IdAlumno = id,
                FechaDesde = cicloLectivo.FechaDesde,
                FechaHasta = cicloLectivo.FechaHasta
            };
            var cursosDelAlumnoCicloLectivo = ObtenerInscripciones(filtro)
                .Where(i => i.Estado == (int) EstadoInscripcion.Inscripto)
                .Select(i => i.Curso);

            return cursosLibres.Where(cl => cursosDelAlumnoCicloLectivo.All(c => c.IDAsignatura != cl.IDAsignatura));
        }

        public void InscribirAlumno(int asignaturaId, int cursoId, int alumnoId)
        {
            var asignatura = Context.AsignaturasRepository.ObtenerAsignatura(asignaturaId);
            if (asignatura == null) throw new Exception($"No existe la asignatura {asignaturaId}");

            var curso = asignatura.Cursos.FirstOrDefault(c => c.IDCurso == cursoId);
            if (curso == null) throw new Exception($"No existe el curso {cursoId}");

            var alumno = Context.AlumnosRepository.ObtenerAlumno(alumnoId);
            if (alumno == null) throw new Exception($"No existe el alumno {alumnoId}");

            var filtro = new FiltroInscripciones
            {
                IdAlumno = alumnoId,
                IdCurso = cursoId,
                IdAsignatura = asignaturaId
            };
            var inscripcionesAlumno = Context.InscripcionesRepository.ObtenerInscripcionesPorFiltro(filtro);

            if(inscripcionesAlumno.Any(i => i.Estado == (int) EstadoInscripcion.Inscripto))
                throw new Exception("El alumno ya se encuentra inscripto en el curso");

            Context.InscripcionesRepository.InscribirAlumno(curso, alumno);
            Context.Commit();
        }
    }
}
