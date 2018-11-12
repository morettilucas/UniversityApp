namespace UniversityApp.DB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FechaInscripcionPK : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Inscripciones");
            AddPrimaryKey("dbo.Inscripciones", new[] { "IDCurso", "IDAlumno", "IDAsignatura", "FechaInscripcion" });
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.Inscripciones");
            AddPrimaryKey("dbo.Inscripciones", new[] { "IDCurso", "IDAlumno" });
        }
    }
}
