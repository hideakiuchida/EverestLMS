CREATE PROCEDURE [dbo].[GetPreguntasDelExamen]
	@IdExamen INT
AS
BEGIN
  SELECT [Id]
      ,[IdPregunta]
      ,[DescripcionPregunta]
      ,[MarcoCorrecto]
      ,[NumeroOrden]
  FROM [dbo].[RespuestaEscalador]
  WHERE [IdExamen] = @IdExamen
END