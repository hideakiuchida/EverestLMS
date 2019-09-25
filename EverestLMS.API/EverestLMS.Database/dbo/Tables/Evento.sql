CREATE TABLE [dbo].[Evento] (
    [IdEvento]      INT IDENTITY (1, 1)  NOT NULL,
    [Titulo]        VARCHAR (200) NOT NULL,
    [Descripcion]   VARCHAR (500) NOT NULL,
    [FechaInicio]	DATETIME NOT NULL,
	[FechaFinal] DATETIME NOT NULL,
	[ColorPrimario] VARCHAR(20) NULL,
	[ColorSecundario] VARCHAR(20) NULL,
    [IdCalendario] INT NOT NULL,
    PRIMARY KEY CLUSTERED ([IdEvento] ASC),
	CONSTRAINT [FK_Evento_Calendario] FOREIGN KEY ([IdCalendario]) REFERENCES [Calendario]([IdCalendario]) ON DELETE CASCADE
);
