namespace UniversityApp.DB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init : DbMigration
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
                "dbo.Inscripciones",
                c => new
                    {
                        IDCurso = c.Int(nullable: false),
                        IDAlumno = c.Int(nullable: false),
                        IDAsignatura = c.Int(nullable: false),
                        FechaInscripcion = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        Estado = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.IDCurso, t.IDAlumno, t.IDAsignatura, t.FechaInscripcion })
                .ForeignKey("dbo.Cursos", t => new { t.IDCurso, t.IDAsignatura })
                .ForeignKey("dbo.Alumnos", t => t.IDAlumno, cascadeDelete: true)
                .Index(t => new { t.IDCurso, t.IDAsignatura })
                .Index(t => t.IDAlumno);
            
            CreateTable(
                "dbo.Cursos",
                c => new
                    {
                        IDCurso = c.Int(nullable: false, identity: true),
                        IDAsignatura = c.Int(nullable: false),
                        CupoMaximo = c.Int(),
                        Docente = c.String(maxLength: 100),
                    })
                .PrimaryKey(t => new { t.IDCurso, t.IDAsignatura })
                .ForeignKey("dbo.Asignaturas", t => t.IDAsignatura, cascadeDelete: true)
                .Index(t => t.IDAsignatura);
            
            CreateTable(
                "dbo.Asignaturas",
                c => new
                    {
                        IDAsignatura = c.Int(nullable: false, identity: true),
                        Nombre = c.String(maxLength: 100),
                    })
                .PrimaryKey(t => t.IDAsignatura);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Inscripciones", "IDAlumno", "dbo.Alumnos");
            DropForeignKey("dbo.Inscripciones", new[] { "IDCurso", "IDAsignatura" }, "dbo.Cursos");
            DropForeignKey("dbo.Cursos", "IDAsignatura", "dbo.Asignaturas");
            DropIndex("dbo.Cursos", new[] { "IDAsignatura" });
            DropIndex("dbo.Inscripciones", new[] { "IDAlumno" });
            DropIndex("dbo.Inscripciones", new[] { "IDCurso", "IDAsignatura" });
            DropTable("dbo.Asignaturas");
            DropTable("dbo.Cursos");
            DropTable("dbo.Inscripciones");
            DropTable("dbo.Alumnos");
        }
    }
}
