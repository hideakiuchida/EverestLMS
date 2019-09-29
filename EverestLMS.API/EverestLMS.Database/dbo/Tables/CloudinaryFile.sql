CREATE TABLE [dbo].[CloudinaryFile]
(
	[IdCloudinaryFile] INT NOT NULL IDENTITY (1,1) PRIMARY KEY,
	[Descripcion] VARCHAR(100) NULL,
	[IdPublico] VARCHAR(100) NULL,
	[Url] VARCHAR(500) NOT NULL,
	[FechaCreacion] DATETIME NOT NULL,
	[IdReferencia] INT NULL,
	CONSTRAINT [FK_CloudinaryFile_Curso] FOREIGN KEY ([IdReferencia]) REFERENCES [Curso]([IdCurso]),
	CONSTRAINT [FK_CloudinaryFile_LeccionMaterial] FOREIGN KEY ([IdReferencia]) REFERENCES [LeccionMaterial]([IdLeccionMaterial]),
	CONSTRAINT [FK_CloudinaryFile_Pregunta] FOREIGN KEY ([IdReferencia]) REFERENCES [Pregunta]([IdPregunta]),
	CONSTRAINT [FK_CloudinaryFile_Respuesta] FOREIGN KEY ([IdReferencia]) REFERENCES [Respuesta]([IdRespuesta]),
	CONSTRAINT [FK_CloudinaryFile_Usuario] FOREIGN KEY ([IdReferencia]) REFERENCES [Usuario]([IdUsuario]) 
)
