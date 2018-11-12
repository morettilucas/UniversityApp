namespace UniversityApp.DB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ForeignKeysUpdated : DbMigration
    {
        public override void Up()
        {
            
            DropPrimaryKey("dbo.Cursos");
            AddPrimaryKey("dbo.Cursos", new[] { "IDCurso", "IDAsignatura" });
            DropForeignKey("dbo.Inscripciones", "IDCurso", "dbo.Cursos");
            DropIndex("dbo.Inscripciones", new[] { "IDCurso" });
            CreateIndex("dbo.Inscripciones", new[] { "IDCurso", "IDAsignatura" });
            AddForeignKey("dbo.Inscripciones", new[] { "IDCurso", "IDAsignatura" }, "dbo.Cursos", new[] { "IDCurso", "IDAsignatura" });
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Inscripciones", new[] { "IDCurso", "IDAsignatura" }, "dbo.Cursos");
            DropIndex("dbo.Inscripciones", new[] { "IDCurso", "IDAsignatura" });
            DropPrimaryKey("dbo.Cursos");
            AddPrimaryKey("dbo.Cursos", "IDCurso");
            CreateIndex("dbo.Inscripciones", "IDCurso");
            AddForeignKey("dbo.Inscripciones", "IDCurso", "dbo.Cursos", "IDCurso");
        }
    }
}
