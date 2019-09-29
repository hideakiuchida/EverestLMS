CREATE TABLE [dbo].[Leccion]
(
	[IdLeccion]       INT           NOT NULL IDENTITY(1,1) PRIMARY KEY,
    [Nombre]        VARCHAR (200) NOT NULL,
    [Descripcion]   VARCHAR (MAX) NOT NULL,
    [IdDificultad]    INT           NOT NULL,
    [Puntaje]       INT           NOT NULL,
    [NumeroOrden]   INT			  NOT NULL,   
    [FechaCreacion] DATETIME2 (0) NOT NULL,
    [IdCurso]       INT           NOT NULL,
	CONSTRAINT [FK_Leccion_Curso] FOREIGN KEY ([IdCurso]) REFERENCES [Curso]([IdCurso]) ON DELETE CASCADE,
	CONSTRAINT [FK_Leccion_Dificultad] FOREIGN KEY ([IdDificultad]) REFERENCES [Dificultad]([IdDificultad])
)
