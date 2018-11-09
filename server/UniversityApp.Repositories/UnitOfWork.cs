using System;
using UniversityApp.DB;
using UniversityApp.Model;
using UniversityApp.Model.Repositories;

namespace UniversityApp.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private UniversityDB Context { get; }
        public IAlumnosRepository AlumnosRepository { get; }
        public IAsignaturasRepository AsignaturasRepository { get; }
        public IInscripcionesRepository InscripcionesRepository { get; }

        public UnitOfWork(
            UniversityDB context,
            IAlumnosRepository alumnosRepository,
            IAsignaturasRepository asignaturasRepository,
            IInscripcionesRepository inscripcionesRepository)
        {
            Context = context ?? throw new ArgumentNullException(nameof(context));
            AlumnosRepository = alumnosRepository ?? throw new ArgumentNullException(nameof(alumnosRepository));
            AsignaturasRepository = asignaturasRepository ?? throw new ArgumentNullException(nameof(asignaturasRepository));
            InscripcionesRepository = inscripcionesRepository ?? throw new ArgumentNullException(nameof(inscripcionesRepository));
        }

        public void Dispose()
        {
            Context.Dispose();
        }

        public int Commit()
        {
            return Context.SaveChanges();
        }
    }
}