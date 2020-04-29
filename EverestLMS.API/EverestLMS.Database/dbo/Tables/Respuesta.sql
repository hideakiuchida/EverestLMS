CREATE TABLE [dbo].[Respuesta]
(
	[IdRespuesta] INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
	[Descripcion] VARCHAR(2000) NOT NULL,
	[EsCorrecto] BIT NOT NULL,
	[IdPregunta] INT NOT NULL,
	CONSTRAINT [FK_Respuesta_Pregunta] FOREIGN KEY ([IdPregunta]) REFERENCES [Pregunta]([IdPregunta]) ON DELETE CASCADE
)
