namespace UniversityApp.DB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Alumnos",
                c => new
                    {
                        IDAlumno = c.Int(nullable: false, identity: true),
                        Nombre = c.String(nullable: false, maxLength: 100),
                        Legajo = c.String(nullable: false, maxLength: 20),
                        Edad = c.Int(),
                        FechaNacimiento = c.DateTime(precision: 7, storeType: "datetime2"),
                    })
                .PrimaryKey(t => t.IDAlumno);
            
            CreateTable(
                "dbo.Inscripcions",
                c => new
                    {
                        IDAlumno = c.Int(nullable: false),
                        IDCurso = c.Int(nullable: false),
                        FechaInscripcion = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        Estado = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => new { t.IDAlumno, t.IDCurso })
                .ForeignKey("dbo.Cursos", t => t.IDCurso)
                .ForeignKey("dbo.Alumnos", t => t.IDAlumno)
                .Index(t => t.IDAlumno)
                .Index(t => t.IDCurso);
            
            CreateTable(
                "dbo.Cursos",
                c => new
                    {
                        IDCurso = c.Int(nullable: false, identity: true),
                        IDAsignatura = c.Int(nullable: false),
                        CupoMaximo = c.Int(),
                        Docente = c.String(maxLength: 100),
                    })
                .PrimaryKey(t => t.IDCurso)
                .ForeignKey("dbo.Asignatura", t => t.IDAsignatura)
                .Index(t => t.IDAsignatura);
            
            CreateTable(
                "dbo.Asignatura",
                c => new
                    {
                        IDAsignatura = c.Int(nullable: false, identity: true),
                        Nombre = c.String(maxLength: 100),
                    })
                .PrimaryKey(t => t.IDAsignatura);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Inscripcions", "IDAlumno", "dbo.Alumnos");
            DropForeignKey("dbo.Inscripcions", "IDCurso", "dbo.Cursos");
            DropForeignKey("dbo.Cursos", "IDAsignatura", "dbo.Asignatura");
            DropIndex("dbo.Cursos", new[] { "IDAsignatura" });
            DropIndex("dbo.Inscripcions", new[] { "IDCurso" });
            DropIndex("dbo.Inscripcions", new[] { "IDAlumno" });
            DropTable("dbo.Asignatura");
            DropTable("dbo.Cursos");
            DropTable("dbo.Inscripcions");
            DropTable("dbo.Alumnos");
        }
    }
}
