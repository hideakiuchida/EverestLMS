CREATE PROCEDURE [dbo].[GetPreguntasDelExamen]
	@IdExamen INT
AS
BEGIN
  SELECT [Id]
      ,[IdPregunta]
      ,[DescripcionPregunta]
      ,[MarcoCorrecto]
  FROM [dbo].[RespuestaEscalador]
  WHERE [IdExamen] = @IdExamen
END