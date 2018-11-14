using AutoMapper;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using UniversityApp.Api.Models;
using UniversityApp.Model;
using UniversityApp.Model.Services;

namespace UniversityApp.Api.Controllers
{
    [RoutePrefix("api/asignaturas")]
    public class AsignaturasController : BaseController
    {
        public IAsignaturasService AsignaturasService { get; set; }

        public AsignaturasController(IAsignaturasService asignaturasService)
        {
            AsignaturasService = asignaturasService ?? throw new ArgumentNullException(nameof(asignaturasService));
        }

        // GET api/asignaturas
        public Task<IEnumerable<AsignaturaDTO>> Get()
        {
            return Task.Factory.StartNew(() => Mapper.Map<IEnumerable<AsignaturaDTO>>(AsignaturasService.ObtenerAsignaturas()));
        }

        // GET api/asignaturas/5
        public Task<AsignaturaDTO> Get(int id)
        {
            return Task.Factory.StartNew(() => Mapper.Map<AsignaturaDTO>(AsignaturasService.ObtenerAsignaturaPorId(id)));
        }

        // GET api/asignaturas/alumnos?idAsignatura=id&desde=fecha&hasta=fecha
        [Route("alumnos")]
        public IHttpActionResult GetAlumnos(int idAsignatura, [FromUri] DateTime fechaDesde, DateTime fechaHasta)
        {
            if (fechaDesde > fechaHasta) return BadRequest("El rango de fechas no es válido");

            var asignatura = AsignaturasService.ObtenerAsignaturaPorId(idAsignatura);
            var cicloLectivo = new CicloLectivo(fechaDesde, fechaHasta);

            return Ok(Mapper.Map<IEnumerable<AlumnoDTO>>(AsignaturasService.ObtenerAlumnosPorAsignatura(asignatura, cicloLectivo)));
        }
    }
}