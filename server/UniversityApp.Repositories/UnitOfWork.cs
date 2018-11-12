using UniversityApp.DB;
using UniversityApp.Model;
using UniversityApp.Model.Repositories;

namespace UniversityApp.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private UniversityDB _context;

        private UniversityDB Context
        {
            get { return _context = _context ?? new UniversityDB(); }
        }

        public IAlumnosRepository AlumnosRepository { get; }
        public IAsignaturasRepository AsignaturasRepository { get; }
        public IInscripcionesRepository InscripcionesRepository { get; }

        public UnitOfWork()
        {
            AlumnosRepository = new AlumnosRepository(Context);
            AsignaturasRepository = new AsignaturasRepository(Context);
            InscripcionesRepository = new InscripcionesRepository(Context);
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