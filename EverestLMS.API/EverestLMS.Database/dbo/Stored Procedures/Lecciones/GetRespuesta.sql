CREATE PROCEDURE [dbo].[GetRespuesta]
	@IdRespuesta int
AS
BEGIN
	SELECT [IdRespuesta], [Descripcion], [EsCorrecto], [IdPregunta]
	FROM [Respuesta]
	WHERE [IdRespuesta] = @IdRespuesta;
END
