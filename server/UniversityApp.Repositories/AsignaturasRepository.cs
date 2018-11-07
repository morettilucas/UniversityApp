using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using UniversityApp.DB;
using UniversityApp.Model.Repositories;

namespace UniversityApp.Repositories
{
    public class AsignaturasRepository: IAsignaturasRepository
    {
        public IEnumerable<Asignatura> ObtenerAsignaturas()
        {
            using (var db = new UniversityDB())
            {
                return db.Asignaturas.Include(m => m.Cursos).ToList();
            }
        }

        public Asignatura ObtenerAsignatura(int id)
        {
            using (var db = new UniversityDB())
            {
                var asignatura = db.Asignaturas.Include(m => m.Cursos).First(a => a.IDAsignatura == id);
                return asignatura ?? throw new Exception($"La asignatura {id} no existe."); 
            }
        }
    }
}
