CREATE TABLE [dbo].[Curso] (
    [IdCurso]       INT           NOT NULL,
    [Nombre]        VARCHAR (200) NOT NULL,
    [Descripcion]   VARCHAR (MAX) NOT NULL,
    [IdDificultad]  INT           NULL,
    [Idioma]        INT           NULL,
    [Puntaje]       INT           NOT NULL,
    [Imagen]        VARCHAR (200) NULL,
    [Autor]         VARCHAR (200) NOT NULL,
    [FechaCreacion] DATETIME2 (0) NOT NULL,
    [IdEtapa]       INT           NULL,
    PRIMARY KEY CLUSTERED ([IdCurso] ASC),
	CONSTRAINT [FK_Curso_Etapa] FOREIGN KEY ([IdEtapa]) REFERENCES [Etapa]([IdEtapa]) ON DELETE CASCADE,
	CONSTRAINT [FK_Curso_Dificultad] FOREIGN KEY ([IdDificultad]) REFERENCES [Dificultad]([IdDificultad]),
	CONSTRAINT [FK_Curso_Idioma] FOREIGN KEY ([Idioma]) REFERENCES [Idioma]([IdIdioma])
);

