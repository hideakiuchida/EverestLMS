CREATE PROCEDURE [dbo].[GetEtapas]
	@IdNivel int NULL,
	@IdLineaCarrera int NULL,
	@Search varchar(100) NULL
AS
BEGIN
	SELECT [IdEtapa]
      ,[Nombre]
      ,[Descripcion]
      ,[NumeroOrden]
      ,[FechaCreacion]
      ,[IdNivel]
      ,[IdLineaCarrera]
  FROM [dbo].[Etapa]
  WHERE (@IdNivel IS NULL OR IdNivel = @IdNivel)
  AND (@IdLineaCarrera IS NULL OR IdLineaCarrera = @IdLineaCarrera)
  AND (@Search IS NULL OR Nombre LIKE '%' + @Search + '%');
END
