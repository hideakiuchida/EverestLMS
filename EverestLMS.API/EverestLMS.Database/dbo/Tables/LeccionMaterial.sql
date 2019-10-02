CREATE TABLE [dbo].[LeccionMaterial]
(
	[IdLeccionMaterial] INT NOT NULL IDENTITY (1, 1) PRIMARY KEY,
	[Titulo] VARCHAR(100) NOT NULL,
	[IdPublico] VARCHAR(100) NULL,
	[Url] VARCHAR(500) NULL,
	[ContenidoTexto] TEXT NULL,
	[IdPresentacion] VARCHAR(500) NULL,
	[IdTipoContenido] INT NOT NULL,
	[IdLeccion] INT NOT NULL,
	CONSTRAINT [FK_LeccionMaterial_Leccion] FOREIGN KEY ([IdLeccion]) REFERENCES [Leccion]([IdLeccion]) ON DELETE CASCADE,
	CONSTRAINT [FK_LeccionMaterial_TipoContenido] FOREIGN KEY ([IdTipoContenido]) REFERENCES [TipoContenido]([IdTipoContenido])
)
