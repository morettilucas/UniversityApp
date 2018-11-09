using AutoMapper;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UniversityApp.Api.Models;
using UniversityApp.Model.Services;

namespace UniversityApp.Api.Controllers
{
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
    }
}