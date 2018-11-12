using AutoMapper;
using System;
using System.Collections.Generic;
using System.Web.Http;
using UniversityApp.Api.Models;
using UniversityApp.Model;
using UniversityApp.Model.Services;

namespace UniversityApp.Api.Controllers
{
    public class InscripcionesController : BaseController
    {
        public IInscripcionesService InscripcionesService { get; set; }

        public InscripcionesController(IInscripcionesService inscripcionesService)
        {
            InscripcionesService =
                inscripcionesService ?? throw new ArgumentNullException(nameof(inscripcionesService));
        }

        // GET api/inscripciones?alumno=id&desde=fecha&hasta=fecha
        [HttpGet]
        public IHttpActionResult Get([FromUri] int alumno = 0, int asignatura = 0, int curso = 0, DateTime? fechaDesde = null, DateTime? fechaHasta = null)
        {
            if (fechaDesde != null && fechaHasta != null && fechaDesde > fechaHasta) return BadRequest("El rango de fechas no es válido");

            var filtro = new FiltroInscripciones
            {
                IdAlumno = alumno,
                IdAsignatura = asignatura,
                IdCurso = curso,
                FechaDesde = fechaDesde,
                FechaHasta = fechaHasta
            };
            return Ok(Mapper.Map<IEnumerable<InscripcionDTO>>(InscripcionesService.ObtenerInscripciones(filtro)));
        }

        // GET api/inscripciones?alumno=id&desde=fecha&hasta=fecha
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