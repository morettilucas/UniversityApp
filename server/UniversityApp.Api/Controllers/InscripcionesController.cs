using AutoMapper;
using System;
using System.Collections.Generic;
using System.Web.Http;
using UniversityApp.Api.Models;
using UniversityApp.DB;
using UniversityApp.Model;
using UniversityApp.Model.Services;

namespace UniversityApp.Api.Controllers
{
    [RoutePrefix("api/inscripciones")]
    public class InscripcionesController : BaseController
    {
        public IInscripcionesService InscripcionesService { get; set; }
        public IAlumnosService AlumnosService { get; set; }

        public InscripcionesController(IInscripcionesService inscripcionesService, IAlumnosService alumnosService)
        {
            InscripcionesService =
                inscripcionesService ?? throw new ArgumentNullException(nameof(inscripcionesService));
            AlumnosService = alumnosService ?? throw new ArgumentNullException(nameof(alumnosService));
        }

        // GET api/inscripciones?idAlumno=id&desde=fecha&hasta=fecha
        [HttpGet]
        public IHttpActionResult Get([FromUri] int idAlumno = 0, int asignatura = 0, int curso = 0,
            DateTime? fechaDesde = null, DateTime? fechaHasta = null)
        {
            if (fechaDesde != null && fechaHasta != null && fechaDesde > fechaHasta) return BadRequest("El rango de fechas no es válido");

            var filtro = new FiltroInscripciones
            {
                IdAlumno = idAlumno,
                IdAsignatura = asignatura,
                IdCurso = curso,
                FechaDesde = fechaDesde,
                FechaHasta = fechaHasta
            };
            return Ok(Mapper.Map<IEnumerable<InscripcionDTO>>(InscripcionesService.ObtenerInscripciones(filtro)));
        }

        // GET api/inscripciones/cursosHabilitados?idAlumno=id&desde=fecha&hasta=fecha
        [HttpGet]
        [Route("cursosHabilitados")]
        public IHttpActionResult GetCursosHabilitadosParaInscripcion([FromUri] int idAlumno, DateTime fechaDesde, DateTime fechaHasta)
        {
            if (fechaDesde > fechaHasta) return BadRequest("El rango de fechas no es válido");
            Alumno alumno;
            try
            {
                alumno = AlumnosService.ObtenerAlumno(idAlumno);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

            return Ok(Mapper.Map<IEnumerable<Curso>, IEnumerable<CursoDTO>>(
                InscripcionesService.ObtenerCursosHabilitadosParaInscripcionPorAlumno(alumno.IDAlumno,
                    new CicloLectivo(fechaDesde, fechaHasta))));
        }

        // POST api/inscripciones
        public IHttpActionResult Post([FromBody] SolicitudInscripcionDTO solicitud)
        {
            InscripcionesService.InscribirAlumno(
                asignaturaId: solicitud.AsignaturaId,
                cursoId: solicitud.CursoId,
                alumnoId: solicitud.AlumnoId);
            return Ok();
        }
    }
}