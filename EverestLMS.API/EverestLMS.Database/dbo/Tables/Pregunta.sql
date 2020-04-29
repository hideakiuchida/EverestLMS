CREATE TABLE [dbo].[Pregunta]
(
	[IdPregunta] INT NOT NULL  IDENTITY(1,1) PRIMARY KEY,
	[Descripcion] VARCHAR(2000) NOT NULL,
	[Imagen] VARCHAR(MAX) NULL,
	[IdLeccion] INT NOT NULL,
	CONSTRAINT [FK_Pregunta_Leccion] FOREIGN KEY ([IdLeccion]) REFERENCES [Leccion]([IdLeccion]) ON DELETE CASCADE
)
