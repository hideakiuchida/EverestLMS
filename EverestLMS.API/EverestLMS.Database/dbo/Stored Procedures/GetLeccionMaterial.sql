CREATE PROCEDURE [dbo].[GetLeccionMaterial]
	@IdLeccionMaterial int,
	@IdLeccion int
AS
BEGIN
SELECT [IdLeccionMaterial]
      ,[Titulo]
      ,[ContenidoTexto]
      ,[IdPresentacion]
      ,[IdTipoContenido]
      ,[IdLeccion]
  FROM [dbo].[LeccionMaterial]
  WHERE [IdLeccion] = @IdLeccion 
  AND [IdLeccionMaterial] = @IdLeccionMaterial;
END
