using AutoMapper;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using UniversityApp.Api.Models;
using UniversityApp.DB;
using UniversityApp.Model.Services;

namespace UniversityApp.Api.Controllers
{
    [RoutePrefix("api/alumnos")]
    public class AlumnosController : BaseController
    {
        public IAlumnosService AlumnosService { get; set; }

        public AlumnosController(IAlumnosService alumnosService)
        {
            AlumnosService = alumnosService ?? throw new ArgumentNullException(nameof(alumnosService));
        }

        // GET api/alumnos
        public Task<IEnumerable<AlumnoDTO>> Get()
        {
            return Task.Factory.StartNew(() => Mapper.Map<IEnumerable<AlumnoDTO>>(AlumnosService.ObtenerAlumnos()));
        }

        // GET api/alumnos/5
        public Task<AlumnoDTO> Get(int id)
        {
            return Task.Factory.StartNew(() => Mapper.Map<AlumnoDTO>(AlumnosService.ObtenerAlumno(id)));
        }

        // POST api/alumnos
        public Task<int> Post([FromBody]AlumnoDTO alumnoDto)
        {
            var alumno = Mapper.Map<Alumno>(alumnoDto);
            return Task.Factory.StartNew(() => AlumnosService.CrearAlumno(alumno));
        }

        // PUT api/alumnos
        public Task Put([FromBody]AlumnoDTO alumnoDto)
        {
            var alumno = Mapper.Map<Alumno>(alumnoDto);
            return Task.Factory.StartNew(() => AlumnosService.ActualizarAlumno(alumno));
        }

        // DELETE api/alumnos/5
        public Task Delete(int id)
        {
            return Task.Factory.StartNew(() => AlumnosService.EliminarAlumno(id));
        }
    }
}