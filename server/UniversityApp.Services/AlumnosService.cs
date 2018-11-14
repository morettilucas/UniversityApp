using System;
using System.Collections.Generic;
using System.Linq;
using UniversityApp.DB;
using UniversityApp.Model;
using UniversityApp.Model.Repositories;
using UniversityApp.Model.Services;

namespace UniversityApp.Services
{
    public class AlumnosService : IAlumnosService
    {
        public IUnitOfWork Context { get; set; }

        public AlumnosService(IUnitOfWork context)
        {
            Context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public IEnumerable<Alumno> ObtenerAlumnos()
        {
            return Context.AlumnosRepository.ObtenerAlumnos();
        }

        public Alumno ObtenerAlumno(int id)
        {
            var alumno = Context.AlumnosRepository.ObtenerAlumno(id);
            if (alumno == null) throw new Exception($"El alumno {id} no existe");
            return alumno;
        }

        public int CrearAlumno(Alumno alumno)
        {
            var id = Context.AlumnosRepository.CrearAlumno(alumno);
            Context.Commit();
            return id;
        }

        public void ActualizarAlumno(Alumno alumno)
        {
            Context.AlumnosRepository.ActualizarAlumno(alumno);
            Context.Commit();
        }

        public void EliminarAlumno(int id)
        {
            Context.AlumnosRepository.EliminarAlumno(id);
            Context.Commit();
        }
    }
}