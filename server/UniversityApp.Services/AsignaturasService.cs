using System;
using System.Collections.Generic;
using UniversityApp.DB;
using UniversityApp.Model;
using UniversityApp.Model.Services;

namespace UniversityApp.Services
{

    public class AsignaturasService: IAsignaturasService
    {
        public IUnitOfWork Context { get; set; }

        public AsignaturasService(IUnitOfWork context)
        {
            Context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public IEnumerable<Asignatura> ObtenerAsignaturas()
        {
            return Context.AsignaturasRepository.ObtenerAsignaturas();
        }

        public Asignatura ObtenerAsignaturaPorId(int id)
        {
            return Context.AsignaturasRepository.ObtenerAsignatura(id);
        }

        public IEnumerable<Alumno> ObtenerAlumnosRecursantesPorAsignatura(Asignatura asignatura)
        {
            throw new NotImplementedException(); // TODO
        }

        public string ObtenerDocente(Asignatura asignatura)
        {
            throw new NotImplementedException(); // TODO
        }
    }
}
