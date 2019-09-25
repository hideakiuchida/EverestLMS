CREATE TABLE [dbo].[LeccionMaterial]
(
	[IdLeccionMaterial] INT NOT NULL IDENTITY (1, 1) PRIMARY KEY,
	[Titulo] VARCHAR(100) NOT NULL,
	[ContenidoTexto] TEXT NULL,
	[ContenidoVideo] VARCHAR(300) NULL,
	[ContenidoPresentacion] VARCHAR(500) NULL,
	[IdTipoContenido] INT NOT NULL,
	[IdLeccion] INT NOT NULL,
	CONSTRAINT [FK_LeccionMaterial_Leccion] FOREIGN KEY ([IdLeccion]) REFERENCES [Leccion]([IdLeccion]),
	CONSTRAINT [FK_LeccionMaterial_TipoContenido] FOREIGN KEY ([IdTipoContenido]) REFERENCES [TipoContenido]([IdTipoContenido])

)
