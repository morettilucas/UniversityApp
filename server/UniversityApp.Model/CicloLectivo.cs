using System;

namespace UniversityApp.Model
{
    public class CicloLectivo
    {
        public DateTime FechaDesde { get; set; }
        public DateTime FechaHasta { get; set; }

        public CicloLectivo(DateTime fechaDesde, DateTime fechaHasta)
        {
            FechaDesde = fechaDesde;
            FechaHasta = fechaHasta;
        }
    }
}