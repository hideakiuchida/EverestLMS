CREATE TABLE [dbo].[CloudinaryFile]
(
	[IdCloudinaryFile] INT NOT NULL IDENTITY (1,1) PRIMARY KEY,
	[Descripcion] VARCHAR(100) NULL,
	[IdPublico] VARCHAR(100) NULL,
	[Url] VARCHAR(500) NOT NULL,
	[FechaCreacion] DATETIME NOT NULL,
	[IdCurso] INT NULL,
	[IdPregunta] INT NULL,
	[IdRespuesta] INT NULL,
	[IdUsuario] INT NULL,
	[IdLeccion] INT NULL
)
