CREATE PROCEDURE [dbo].[GetLeccionesMaterial]
	@IdLeccion int
AS
BEGIN
SELECT [IdLeccionMaterial]
      ,[Titulo]
      , tc.[Descripcion] AS TipoContenidoDescripcion
      ,[IdLeccion]
      , lm.IdTipoContenido
      , lm.Url
      , lm.ContenidoTexto
  FROM [dbo].[LeccionMaterial] lm 
  LEFT JOIN [dbo].[TipoContenido] tc ON lm.IdTipoContenido = tc.IdTipoContenido
  WHERE [IdLeccion] = @IdLeccion;
END
