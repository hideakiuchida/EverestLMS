CREATE TABLE [dbo].[Leccion]
(
	[IdLeccion]     INT           NOT NULL IDENTITY(1,1) PRIMARY KEY,
    [Nombre]        VARCHAR (200) NOT NULL,
    [Descripcion]   VARCHAR (MAX) NOT NULL,
    [ContenidoHTML] TEXT NULL,
    [Puntaje]       INT           NOT NULL,
    [NumeroOrden]   INT			  NOT NULL,   
    [FechaCreacion] DATETIME2 (0) NOT NULL,
    [IdCurso]       INT           NOT NULL,
	CONSTRAINT [FK_Leccion_Curso] FOREIGN KEY ([IdCurso]) REFERENCES [Curso]([IdCurso]) ON DELETE CASCADE
)
