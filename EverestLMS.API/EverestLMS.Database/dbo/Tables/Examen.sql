CREATE TABLE [dbo].[Examen]
(
	[Id] INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
	[UsuarioKey] VARCHAR(1000) NOT NULL,
	[IdEtapa] INT NOT NULL,
    [IdCurso] INT NOT NULL,
	[IdLeccion] INT NULL,
	[Nota] DECIMAL(5,2) NULL,
	[VidasRestante] INT NOT NULL,
	[TiempoRestante] INT NOT NULL,
	[NumeroPreguntaActual] INT NOT NULL,
	[FechaFinalizado] DATETIME NULL
)
