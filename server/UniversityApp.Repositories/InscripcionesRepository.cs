using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using UniversityApp.DB;
using UniversityApp.Model;
using UniversityApp.Model.Repositories;

namespace UniversityApp.Repositories
{
    public class InscripcionesRepository : IInscripcionesRepository
    {
        public UniversityDB Context { get; set; }

        public InscripcionesRepository(UniversityDB context)
        {
            Context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public IEnumerable<Inscripcion> ObtenerInscripcionesPorFiltro(FiltroInscripciones filtro)
        {
            var query = Context.Inscripciones.AsQueryable();

            if (filtro.IdAlumno != 0) query = query.Where(i => filtro.IdAlumno == i.IDAlumno);
            if (filtro.IdCurso != 0) query = query.Where(i => filtro.IdCurso == i.IDCurso);
            if (filtro.IdAsignatura != 0) query = query.Where(i => filtro.IdAsignatura == i.IDAsignatura);
            if (filtro.FechaDesde != null) query = query.Where(i => filtro.FechaDesde < i.FechaInscripcion);
            if (filtro.FechaHasta != null) query = query.Where(i => i.FechaInscripcion < filtro.FechaHasta);

            return query
                .Include(inscripcion => inscripcion.Alumno)
                .Include(inscripcion => inscripcion.Curso);
        }

        public void InscribirAlumno(Curso curso, Alumno alumno)
        {
            var inscripcion = new Inscripcion
            {
                Alumno = alumno,
                Curso = curso,
                FechaInscripcion = DateTime.Now,
                Estado = (int) EstadoInscripcion.Inscripto,
                IDCurso = alumno.IDAlumno,
                IDAlumno = curso.IDCurso,
                IDAsignatura = curso.IDAsignatura
            };
            Context.Inscripciones.Add(inscripcion);
        }
    }
}