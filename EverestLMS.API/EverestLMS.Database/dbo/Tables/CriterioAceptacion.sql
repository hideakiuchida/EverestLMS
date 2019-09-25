CREATE TABLE [dbo].[CriterioAceptacion]
(
	[IdCriterioAceptacion] INT IDENTITY (1, 1) NOT NULL,
    [Descripcion]   VARCHAR (1000) NOT NULL,
    [Medida]	    VARCHAR(20) NULL,
    [Valor]         DECIMAL(10,2)    NULL,
    [IdCalendario]  INT   NOT NULL,
    PRIMARY KEY CLUSTERED ([IdCriterioAceptacion] ASC),
	CONSTRAINT [FK_CriterioAceptacion_Calendario] FOREIGN KEY ([IdCalendario]) REFERENCES [Calendario]([IdCalendario]) ON DELETE CASCADE
)
