using System;

namespace UniversityApp.Model
{
    public class FiltroInscripciones
    {
        public int IdAlumno { get; set; }
        public DateTime? FechaDesde { get; set; }
        public DateTime? FechaHasta { get; set; }
    }
}