using System;
using System.Collections.Generic;
using UniversityApp.DB;
using UniversityApp.Model.Repositories;
using UniversityApp.Model.Services;

namespace UniversityApp.Services
{
    public class EstadoAcademicoService: IEstadoAcademicoService
    {
        public IAlumnosRepository AlumnosRepository { get; set; }

        public EstadoAcademicoService(IAlumnosRepository alumnosRepository)
        {
            this.AlumnosRepository = alumnosRepository ?? throw new ArgumentNullException(nameof(alumnosRepository));
        }

        public IEnumerable<Curso> ObtenerEstadoAcademicoPorAlumno(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}
