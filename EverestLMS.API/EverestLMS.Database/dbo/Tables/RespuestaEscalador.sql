CREATE TABLE [dbo].[RespuestaEscalador]
(
	[Id] INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
	[IdPregunta] INT NOT NULL,
	[DescripcionPregunta] VARCHAR(2000) NOT NULL,
	[IdRespuesta] INT NULL,
	[DescripcionRespuesta] VARCHAR(2000) NULL,
	[MarcoCorrecto] BIT NULL,
	[IdExamen] INT NOT NULL,
	[NumeroOrden] INT NOT NULL
)
