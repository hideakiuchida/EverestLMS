CREATE TABLE [dbo].[Etapa] (
    [IdEtapa]        INT           NOT NULL,
    [Nombre]         VARCHAR (100) NOT NULL,
    [Descripcion]    VARCHAR (500) NOT NULL,
    [NumeroOrden]    INT           NOT NULL,
    [FechaCreacion]  DATETIME	  NOT NULL,
    [IdNivel]        INT           NULL,
    [IdLineaCarrera] INT           NULL,
    PRIMARY KEY CLUSTERED ([IdEtapa] ASC),
	CONSTRAINT [FK_Etapa_Nivel] FOREIGN KEY ([IdNivel]) REFERENCES [Nivel]([IdNivel]) ON DELETE CASCADE,
	CONSTRAINT [FK_Etapa_LineaCarrera] FOREIGN KEY ([IdLineaCarrera]) REFERENCES [LineaCarrera]([IdLineaCarrera]) ON DELETE CASCADE
);

