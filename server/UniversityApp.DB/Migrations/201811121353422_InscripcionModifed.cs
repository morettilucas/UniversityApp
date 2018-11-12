namespace UniversityApp.DB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InscripcionModifed : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Inscripcions", newName: "Inscripciones");
            DropPrimaryKey("dbo.Inscripciones");
            AddColumn("dbo.Inscripciones", "IDAsignatura", c => c.Int(nullable: false));
            AlterColumn("dbo.Inscripciones", "Estado", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.Inscripciones", new[] { "IDCurso", "IDAlumno" });
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.Inscripciones");
            AlterColumn("dbo.Inscripciones", "Estado", c => c.String(nullable: false, maxLength: 50));
            DropColumn("dbo.Inscripciones", "IDAsignatura");
            AddPrimaryKey("dbo.Inscripciones", new[] { "IDAlumno", "IDCurso" });
            RenameTable(name: "dbo.Inscripciones", newName: "Inscripcions");
        }
    }
}
