using System;
using System.Collections.Generic;
using System.Linq;
using UniversityApp.DB;
using UniversityApp.Model.Repositories;

namespace UniversityApp.Repositories
{
    public class AlumnosRepository: IAlumnosRepository
    {
        public IEnumerable<Alumno> ObtenerAlumnos()
        {
            using (var db = new UniversityDB())
            {
                return db.Alumnos.ToList();
            }
        }

        public Alumno ObtenerAlumno(int id)
        {
            using (var db = new UniversityDB())
            {
                var alumno = db.Alumnos.Find(id);
                return alumno ?? throw new Exception($"El alumno {id} no existe."); 
            }
        }

        public int CrearAlumno(Alumno alumno)
        {
            using (var db = new UniversityDB())
            {
                var alumnoAdded = db.Alumnos.Add(alumno);
                db.SaveChanges();

                return alumnoAdded.IDAlumno;
            }
        }

        public void ActualizarAlumno(Alumno alumno)
        {
            using (var db = new UniversityDB())
            {
                var alumnoDb = db.Alumnos.Find(alumno.IDAlumno);
                if(alumnoDb == null) throw new Exception($"El alumno {alumno.IDAlumno} no existe.");

                db.Entry(alumnoDb).CurrentValues.SetValues(alumno);
                db.SaveChanges();
            }
        }

        public void EliminarAlumno(int id)
        {
            using (var db = new UniversityDB())
            {
                var alumnoDb = db.Alumnos.Find(id);
                if (alumnoDb == null) return;

                db.Alumnos.Remove(alumnoDb);
                db.SaveChanges();
            }
        }
    }
}
