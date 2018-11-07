CREATE TABLE [dbo].Alumnos
(
	[IDAlumno] INT NOT NULL PRIMARY KEY, 
    [Nombre] NVARCHAR(100) NOT NULL, 
    [Legajo] NVARCHAR(20) NOT NULL, 
    [Edad] INT NULL, 
    [FechaNacimiento] DATETIME2 NULL
)
