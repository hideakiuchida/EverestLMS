CREATE TABLE [dbo].[Calendario] (
    [IdCalendario] INT IDENTITY (1, 1) NOT NULL,
    [Descripcion]    VARCHAR (100) NOT NULL,
	[FechaInicio] DATETIME NOT NULL,
	[FechaFinal] DATETIME NOT NULL,
	[Activo] BIT NOT NULL,
	[Temporada] VARCHAR(20) NOT NULL,
    PRIMARY KEY CLUSTERED ([IdCalendario] ASC)
);