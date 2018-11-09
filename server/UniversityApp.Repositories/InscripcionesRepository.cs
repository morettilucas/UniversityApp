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
            var query = Context.Inscripciones.Where(i => i.Alumno.IDAlumno == filtro.IdAlumno);

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
                Estado = EstadoInscripcion.Inscripto,
                IDCurso = alumno.IDAlumno,
                IDAlumno = curso.IDCurso
            };
            alumno.Inscripciones.Add(inscripcion);
            curso.Inscripciones.Add(inscripcion);
            Context.Inscripciones.Add(inscripcion);
        }
    }
}