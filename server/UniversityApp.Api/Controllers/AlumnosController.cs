using AutoMapper;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using UniversityApp.Api.Models;
using UniversityApp.DB;
using UniversityApp.Model.Repositories;

namespace UniversityApp.Api.Controllers
{
    public class AlumnosController : BaseController
    {
        public IAlumnosRepository AlumnosRepository { get; set; }

        public AlumnosController(IAlumnosRepository alumnosRepository)
        {
            AlumnosRepository = alumnosRepository ?? throw new ArgumentNullException(nameof(alumnosRepository));
        }

        // GET api/alumnos
        public Task<IEnumerable<AlumnoDTO>> Get()
        {
            return Task.Factory.StartNew(() => Mapper.Map<IEnumerable<AlumnoDTO>>(AlumnosRepository.ObtenerAlumnos()));
        }

        // GET api/alumnos/5
        public Task<AlumnoDTO> Get(int id)
        {
            return Task.Factory.StartNew(() => Mapper.Map<AlumnoDTO>(AlumnosRepository.ObtenerAlumno(id)));
        }

        // POST api/alumnos
        public Task<int> Post([FromBody]AlumnoDTO alumnoDto)
        {
            var alumno = Mapper.Map<Alumno>(alumnoDto);
            return Task.Factory.StartNew(() => AlumnosRepository.CrearAlumno(alumno));
        }

        // PUT api/alumnos/5
        public Task Put(int id, [FromBody]AlumnoDTO alumnoDto)
        {
            var alumno = Mapper.Map<Alumno>(alumnoDto);
            return Task.Factory.StartNew(() =>  AlumnosRepository.ActualizarAlumno(alumno));
        }

        // DELETE api/alumnos/5
        public Task Delete(int id)
        {
            return Task.Factory.StartNew(() => AlumnosRepository.EliminarAlumno(id));
        }
    }
}