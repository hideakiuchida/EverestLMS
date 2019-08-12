CREATE TABLE [dbo].[Curso] (
    [IdCurso]       INT           NOT NULL,
    [Nombre]        VARCHAR (200) NOT NULL,
    [Descripcion]   VARCHAR (MAX) NOT NULL,
    [Dificultad]    INT           NOT NULL,
    [Idioma]        INT           NOT NULL,
    [Puntaje]       INT           NOT NULL,
    [Imagen]        VARCHAR (200) NOT NULL,
    [Autor]         VARCHAR (200) NOT NULL,
    [FechaCreacion] DATETIME2 (0) NOT NULL,
    [IdEtapa]       INT           NULL,
    PRIMARY KEY CLUSTERED ([IdCurso] ASC),
	CONSTRAINT [FK_Curso_Etapa] FOREIGN KEY ([IdEtapa]) REFERENCES [Etapa]([IdEtapa]) ON DELETE CASCADE
);

