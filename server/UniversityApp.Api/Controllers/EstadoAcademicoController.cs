using System;
using System.Threading.Tasks;
using System.Web.Http;
using AutoMapper;
using UniversityApp.Api.Models;
using UniversityApp.Model;
using UniversityApp.Model.Services;

namespace UniversityApp.Api.Controllers
{
    [RoutePrefix("api/estadoAcademico")]
    public class EstadoAcademicoController : BaseController
    {
        public IEstadoAcademicoService EstadoAcademicoService { get; set; }

        public EstadoAcademicoController(IEstadoAcademicoService estadoAcademicoService)
        {
            EstadoAcademicoService =
                estadoAcademicoService ?? throw new ArgumentNullException(nameof(estadoAcademicoService));
        }

        // GET api/estadoAcademico?idAlumno=1
        public Task<EstadoAcademicoDTO> Get([FromUri] int idAlumno)
        {
            return Task.Factory.StartNew(() => Mapper.Map<EstadoAcademico, EstadoAcademicoDTO>(EstadoAcademicoService.ObtenerEstadoAcademicoPorAlumno(idAlumno)));
        }
    }
}