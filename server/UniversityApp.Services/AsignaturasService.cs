using System;
using System.Collections.Generic;
using System.Linq;
using UniversityApp.DB;
using UniversityApp.Model;
using UniversityApp.Model.Services;

namespace UniversityApp.Services
{
    public class AsignaturasService : IAsignaturasService
    {
        public IUnitOfWork Context { get; set; }

        public AsignaturasService(IUnitOfWork context)
        {
            Context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public IEnumerable<Asignatura> ObtenerAsignaturas()
        {
            return Context.AsignaturasRepository.ObtenerAsignaturas();
        }

        public Asignatura ObtenerAsignaturaPorId(int id)
        {
            return Context.AsignaturasRepository.ObtenerAsignatura(id);
        }

        public IEnumerable<Curso> ObtenerCursosLibres(CicloLectivo cicloLectivo)
        {
            var filtro = new FiltroInscripciones
            {
                FechaDesde = cicloLectivo.FechaDesde,
                FechaHasta = cicloLectivo.FechaHasta
            };
            var cursos = ObtenerAsignaturas().SelectMany(a =>  a.Cursos);

            var cursosOcupados = from inscripcion in Context.InscripcionesRepository.ObtenerInscripcionesPorFiltro(filtro)
                group inscripcion by inscripcion.Curso
                into inscripcionesPorCurso
                where inscripcionesPorCurso.Count() >= inscripcionesPorCurso.Key.CupoMaximo
                select inscripcionesPorCurso.Key;

            return cursos.Except(cursosOcupados);
        }

        public IEnumerable<Alumno> ObtenerAlumnosPorAsignatura(Asignatura asignatura, CicloLectivo cicloLectivo)
        {
            var filtro = new FiltroInscripciones
            {
                FechaDesde = cicloLectivo.FechaDesde,
                FechaHasta = cicloLectivo.FechaHasta,
                IdAsignatura = asignatura.IDAsignatura
            };
            return from inscripcion in Context.InscripcionesRepository.ObtenerInscripcionesPorFiltro(filtro)
                group inscripcion by inscripcion.Alumno
                into grupo
                let inscripciones = grupo.OrderByDescending(i => i.FechaInscripcion)
                where inscripciones.Any() && inscripciones.First().Estado == (int) EstadoInscripcion.Inscripto
                select inscripciones.First().Alumno;
        }

        public IEnumerable<Alumno> ObtenerAlumnosRecursantesPorAsignatura(Asignatura asignatura)
        {
            var filtro = new FiltroInscripciones
            {
                IdAsignatura = asignatura.IDAsignatura
            };
            return from inscripcion in Context.InscripcionesRepository.ObtenerInscripcionesPorFiltro(filtro)
                group inscripcion by inscripcion.Alumno
                into grupo
                let inscripciones = grupo.OrderByDescending(i => i.FechaInscripcion)
                where inscripciones.Any() && inscripciones.First().Estado == (int) EstadoInscripcion.NoRegular
                select inscripciones.First().Alumno;
        }
    }
}