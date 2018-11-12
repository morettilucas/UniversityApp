using System;

namespace UniversityApp.Model
{
    public class FiltroInscripciones
    {
        public int IdAlumno { get; set; }
        public int IdAsignatura { get; set; }
        public int IdCurso { get; set; }
        public DateTime? FechaDesde { get; set; }
        public DateTime? FechaHasta { get; set; }
    }
}