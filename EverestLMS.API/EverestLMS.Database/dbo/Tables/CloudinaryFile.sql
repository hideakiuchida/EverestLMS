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
	CONSTRAINT [FK_CloudinaryFile_Curso] FOREIGN KEY ([IdCurso]) REFERENCES [Curso]([IdCurso]),
	CONSTRAINT [FK_CloudinaryFile_Pregunta] FOREIGN KEY ([IdPregunta]) REFERENCES [Pregunta]([IdPregunta]),
	CONSTRAINT [FK_CloudinaryFile_Respuesta] FOREIGN KEY ([IdRespuesta]) REFERENCES [Respuesta]([IdRespuesta]),
	CONSTRAINT [FK_CloudinaryFile_Usuario] FOREIGN KEY ([IdUsuario]) REFERENCES [Usuario]([IdUsuario]) 
)
