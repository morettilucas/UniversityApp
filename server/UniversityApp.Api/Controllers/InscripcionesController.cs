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
    public class InscripcionesController : BaseController
    {
        public IInscripcionesService InscripcionesService { get; set; }

        public InscripcionesController(IInscripcionesService inscripcionesService)
        {
            InscripcionesService =
                inscripcionesService ?? throw new ArgumentNullException(nameof(inscripcionesService));
        }

        // GET api/inscripciones?alumno=id&desde=fecha&hasta=fecha
        public IHttpActionResult Get([FromUri] int alumno, [FromUri] DateTime? fechaDesde, [FromUri] DateTime? fechaHasta)
        {
            if (fechaDesde != null && fechaHasta != null && fechaDesde > fechaHasta) return BadRequest("El rango de fechas no es válido");

            var filtro = new FiltroInscripciones
            {
                IdAlumno = alumno,
                FechaDesde = fechaDesde,
                FechaHasta = fechaHasta
            };
            return Ok(Mapper.Map<IEnumerable<InscripcionDTO>>(InscripcionesService.ObtenerInscripciones(filtro)));
        }

        // GET api/inscripciones?alumno=id&desde=fecha&hasta=fecha
        public IHttpActionResult Post([FromBody] AlumnoDTO alumnoDto, CursoDTO cursoDto)
        {
            var alumno = Mapper.Map<Alumno>(alumnoDto);
            var curso = Mapper.Map<Curso>(cursoDto);

            InscripcionesService.InscribirAlumno(curso, alumno);
            return Ok();
        }
    }
}