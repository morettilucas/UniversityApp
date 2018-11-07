CREATE TABLE [dbo].Cursos
(
	[IDCurso] INT NOT NULL PRIMARY KEY, 
    [Asignatura] NVARCHAR(100) NULL, 
    [CupoMaximo] INT NULL, 
    [Docente] NVARCHAR(100) NULL
)
