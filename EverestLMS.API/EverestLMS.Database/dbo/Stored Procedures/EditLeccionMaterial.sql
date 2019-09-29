CREATE PROCEDURE [dbo].[EditLeccionMaterial]
	@IdLeccionMaterial int,
	@Titulo varchar(100),
	@ContenidoTexto text,
	@IdPresentacion varchar(500),
	@IdTipoContenido int,
	@IdLeccion int
AS
BEGIN
UPDATE [dbo].[LeccionMaterial]
   SET [Titulo] = CASE WHEN @Titulo IS NULL THEN [Titulo] ELSE @Titulo END
      ,[ContenidoTexto] = CASE WHEN @ContenidoTexto IS NULL THEN [ContenidoTexto] ELSE @ContenidoTexto END
      ,[IdPresentacion] = CASE WHEN @IdPresentacion IS NULL THEN [IdPresentacion] ELSE @IdPresentacion END
      ,[IdTipoContenido] = CASE WHEN @IdTipoContenido IS NULL THEN [IdTipoContenido] ELSE @IdTipoContenido END
 WHERE IdLeccion = @IdLeccion
 AND IdLeccionMaterial = @IdLeccionMaterial;
 SELECT @@ROWCOUNT;
END
