namespace UniversityApp.DB
{
    using System.Data.Entity;

    public partial class UniversityDB : DbContext
    {
        public UniversityDB()
            : base("name=UniversityDB")
        {
        }

        public virtual DbSet<Alumno> Alumnos { get; set; }
        public virtual DbSet<Curso> Cursos { get; set; }
        public virtual DbSet<Inscripcion> Inscripciones { get; set; }
        public virtual DbSet<Asignatura> Asignaturas { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Alumno>()
                .HasMany(e => e.Inscripciones)
                .WithRequired(e => e.Alumno)
                .WillCascadeOnDelete(true);

            modelBuilder.Entity<Asignatura>()
                .HasMany(c => c.Cursos);

            modelBuilder.Entity<Curso>()
                .HasMany(e => e.Inscripciones)
                .WithRequired(e => e.Curso)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Curso>()
                .HasRequired(c => c.Asignatura)
                .WithMany(a => a.Cursos)
                .HasForeignKey(c => c.IDAsignatura)
                .WillCascadeOnDelete(true);

            modelBuilder.Entity<Inscripcion>()
                .HasKey(i => new {i.IDCurso, i.IDAlumno, i.IDAsignatura, i.FechaInscripcion})
                .Property(e => e.Estado)
                .HasColumnType("int");

            
        }
    }
}
