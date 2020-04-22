CREATE PROCEDURE [dbo].[GetRespuestas]
	@IdPregunta int
AS
BEGIN
	SELECT [IdRespuesta], [Descripcion], [EsCorrecto], [IdPregunta]
	FROM [Respuesta]
	WHERE [IdPregunta] = @IdPregunta;
END

