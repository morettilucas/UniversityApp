namespace UniversityApp.DB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AsignaturasTableModified : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Asignatura", newName: "Asignaturas");
            DropForeignKey("dbo.Inscripciones", "IDAsignatura", "dbo.Asignatura");
            DropIndex("dbo.Inscripciones", new[] { "IDAsignatura" });
        }
        
        public override void Down()
        {
            CreateIndex("dbo.Inscripciones", "IDAsignatura");
            AddForeignKey("dbo.Inscripciones", "IDAsignatura", "dbo.Asignatura", "IDAsignatura", cascadeDelete: true);
            RenameTable(name: "dbo.Asignaturas", newName: "Asignatura");
        }
    }
}
