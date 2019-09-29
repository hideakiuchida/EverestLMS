CREATE PROCEDURE [dbo].[GetLeccionesMaterial]
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
  WHERE [IdLeccion] = @IdLeccion;
END
