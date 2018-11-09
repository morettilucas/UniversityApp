using System;
using System.Collections.Generic;
using System.Linq;
using UniversityApp.DB;
using UniversityApp.Model.Repositories;

namespace UniversityApp.Repositories
{
    public class AlumnosRepository : IAlumnosRepository
    {
        public UniversityDB Context { get; set; }

        public AlumnosRepository(UniversityDB context)
        {
            Context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public IEnumerable<Alumno> ObtenerAlumnos()
        {
            return Context.Alumnos.ToList();
        }

        public Alumno ObtenerAlumno(int id)
        {
            var alumno = Context.Alumnos.Find(id);
            return alumno ?? throw new Exception($"El alumno {id} no existe.");
        }

        public int CrearAlumno(Alumno alumno)
        {
            var alumnoAdded = Context.Alumnos.Add(alumno);
            return alumnoAdded.IDAlumno;
        }

        public void ActualizarAlumno(Alumno alumno)
        {
            var alumnoDb = Context.Alumnos.Find(alumno.IDAlumno);
            if (alumnoDb == null) throw new Exception($"El alumno {alumno.IDAlumno} no existe.");

            Context.Entry(alumnoDb).CurrentValues.SetValues(alumno);
        }

        public void EliminarAlumno(int id)
        {
            var alumnoDb = Context.Alumnos.Find(id);
            if (alumnoDb == null) return;

            Context.Alumnos.Remove(alumnoDb);
        }
    }
}