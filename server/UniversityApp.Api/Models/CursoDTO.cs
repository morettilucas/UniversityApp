namespace UniversityApp.Api.Models
{
    public class CursoDTO
    {
        public int IDCurso { get; set; }
        public AsignaturaDTO Asignatura { get; set; }
        public int? CupoMaximo { get; set; }
        public string Docente { get; set; }
    }
}
