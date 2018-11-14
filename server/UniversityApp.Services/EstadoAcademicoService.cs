using System;
using System.Collections.Generic;
using System.Linq;
using UniversityApp.DB;
using UniversityApp.Model;
using UniversityApp.Model.Services;

namespace UniversityApp.Services
{
    public class EstadoAcademicoService: IEstadoAcademicoService
    {
        public IUnitOfWork Context { get; set; }

        public EstadoAcademicoService(IUnitOfWork context)
        {
            Context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public EstadoAcademico ObtenerEstadoAcademicoPorAlumno(int id)
        {
            var alumno = Context.AlumnosRepository.ObtenerAlumno(id);
            if(alumno == null) throw new Exception($"El alumno {id} no existe");

            var filtro = new FiltroInscripciones
            {
                IdAlumno = alumno.IDAlumno
            };

            var inscripciones = Context.InscripcionesRepository.ObtenerInscripcionesPorFiltro(filtro).ToList();

            var ultimaInscripcionTable = from inscripcion in inscripciones
                group inscripcion by inscripcion.IDAsignatura
                into grupo
                let ultimaInscripcion = grupo.OrderByDescending(i => i.FechaInscripcion).FirstOrDefault()
                where ultimaInscripcion != null
                select new KeyValuePair<int, Inscripcion> (ultimaInscripcion.Curso.IDAsignatura, ultimaInscripcion);

            var ultimaInscripcionPorAsignatura = ultimaInscripcionTable.ToDictionary(pair => Context.AsignaturasRepository.ObtenerAsignatura(pair.Key), pair => pair.Value);

            var asignaturas = Context.AsignaturasRepository.ObtenerAsignaturas().ToList();

            var estado = new EstadoAcademico
            {
                IDAlumno = alumno.IDAlumno,
                AsignaturasInscripto = ultimaInscripcionPorAsignatura.Where(pair => pair.Value.Estado == (int) EstadoInscripcion.Inscripto).Select(pair => pair.Key).ToList(),
                AsignaturasNoRegular = ultimaInscripcionPorAsignatura.Where(pair => pair.Value.Estado == (int) EstadoInscripcion.NoRegular).Select(pair => pair.Key).ToList()
            };
            estado.AsignaturasPorCursar = asignaturas.Except(estado.AsignaturasInscripto).ToList();

            return estado;
        }
    }
}
