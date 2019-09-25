CREATE TABLE [dbo].[Pregunta]
(
	[IdPregunta] INT NOT NULL  IDENTITY(1,1) PRIMARY KEY,
	[Descripción] VARCHAR(200) NOT NULL,
	[Imagen] VARCHAR(300) NULL,
	[IdLeccion] INT NOT NULL,
	CONSTRAINT [FK_Pregunta_Leccion] FOREIGN KEY ([IdLeccion]) REFERENCES [Leccion]([IdLeccion]) ON DELETE CASCADE
)
