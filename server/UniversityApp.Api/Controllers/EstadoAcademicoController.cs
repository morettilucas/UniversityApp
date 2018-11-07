using System;
using UniversityApp.Model.Repositories;

namespace UniversityApp.Api.Controllers
{
    public class EstadoAcademicoController : BaseController
    {
        public IAlumnosRepository AlumnosRepository { get; set; }

        public EstadoAcademicoController(IAlumnosRepository alumnosRepository)
        {
            AlumnosRepository = alumnosRepository ?? throw new ArgumentNullException(nameof(alumnosRepository));
        }
    }
}