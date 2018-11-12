namespace UniversityApp.DB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddAsignaturaInscripcion : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.Inscripciones", "IDAsignatura");
            AddForeignKey("dbo.Inscripciones", "IDAsignatura", "dbo.Asignatura", "IDAsignatura", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Inscripciones", "IDAsignatura", "dbo.Asignatura");
            DropIndex("dbo.Inscripciones", new[] { "IDAsignatura" });
        }
    }
}
