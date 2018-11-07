CREATE TABLE [dbo].Inscripciones
(
	[IDAlumno] INT NOT NULL , 
    [IDCurso] INT NOT NULL, 
    [FechaInscripcion] DATETIME2 NOT NULL, 
    [Estado] NVARCHAR(50) NOT NULL, 
    PRIMARY KEY ([IDCurso], [IDAlumno]), 
    CONSTRAINT [FK_Inscripciones_Alumnos] FOREIGN KEY ([IDAlumno]) REFERENCES Alumnos(IDAlumno),
    CONSTRAINT [FK_Inscripciones_Cursos] FOREIGN KEY ([IDCurso]) REFERENCES Cursos(IDCurso)
)
