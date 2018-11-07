using System;

namespace UniversityApp.Api.Models
{
    public class AlumnoDTO
    {
        public int IDAlumno { get; set; }
        public string Nombre { get; set; }
        public string Legajo { get; set; }
        public int Edad { get; set; }
        public DateTime FechaNacimiento { get; set; }
    }
}
