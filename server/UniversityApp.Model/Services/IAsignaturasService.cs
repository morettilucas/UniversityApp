﻿using System.Collections.Generic;
using UniversityApp.DB;

namespace UniversityApp.Model.Services
{
    public interface IAsignaturasService
    {
        IEnumerable<Asignatura> ObtenerAsignaturas();
        Asignatura ObtenerAsignaturaPorId(int id);
        IEnumerable<Curso> ObtenerCursosLibres(CicloLectivo cicloLectivo);
        IEnumerable<Alumno> ObtenerAlumnosPorCurso(Curso curso, CicloLectivo cicloLectivo);
        IEnumerable<Alumno> ObtenerAlumnosRecursantesPorAsignatura(Asignatura asignatura);
    }
}
