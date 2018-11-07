using AutoMapper;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UniversityApp.Api.Models;
using UniversityApp.Model.Repositories;

namespace UniversityApp.Api.Controllers
{
    public class AsignaturasController : BaseController
    {
        public IAsignaturasRepository AsignaturasRepository { get; set; }

        public AsignaturasController(IAsignaturasRepository asignaturasRepository)
        {
            AsignaturasRepository = asignaturasRepository ?? throw new ArgumentNullException(nameof(asignaturasRepository));
        }

        // GET api/asignaturas
        public Task<IEnumerable<AsignaturaDTO>> Get()
        {
            return Task.Factory.StartNew(() => Mapper.Map<IEnumerable<AsignaturaDTO>>(AsignaturasRepository.ObtenerAsignaturas()));
        }

        // GET api/asignaturas/5
        public Task<AsignaturaDTO> Get(int id)
        {
            return Task.Factory.StartNew(() =>
            {
                var asig = AsignaturasRepository.ObtenerAsignatura(id);
                var map = Mapper.Map<AsignaturaDTO>(asig);
                return map;
            });
        }
    }
}