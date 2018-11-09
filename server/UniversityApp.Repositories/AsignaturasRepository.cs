using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using UniversityApp.DB;
using UniversityApp.Model.Repositories;

namespace UniversityApp.Repositories
{
    public class AsignaturasRepository : IAsignaturasRepository
    {
        public UniversityDB Context { get; set; }

        public AsignaturasRepository(UniversityDB context)
        {
            Context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public IEnumerable<Asignatura> ObtenerAsignaturas()
        {
            return Context.Asignaturas.Include(m => m.Cursos).ToList();
        }

        public Asignatura ObtenerAsignatura(int id)
        {
            var asignatura = Context.Asignaturas.Include(m => m.Cursos).First(a => a.IDAsignatura == id);
            return asignatura ?? throw new Exception($"La asignatura {id} no existe.");
        }
    }
}