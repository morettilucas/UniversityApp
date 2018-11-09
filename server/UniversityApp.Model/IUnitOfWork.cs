using System;
using UniversityApp.Model.Repositories;

namespace UniversityApp.Model
{
    public interface IUnitOfWork: IDisposable
    {
        IAlumnosRepository AlumnosRepository { get; }
        IAsignaturasRepository AsignaturasRepository { get; }
        IInscripcionesRepository InscripcionesRepository { get; }
        int Commit();
    }
}
