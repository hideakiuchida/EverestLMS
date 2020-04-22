CREATE PROCEDURE [dbo].[GetPregunta]
	@IdPregunta int
AS
BEGIN
	SELECT [IdPregunta], [Descripcion], [Imagen], [IdLeccion]
	FROM [Pregunta]
	WHERE [IdPregunta] = @IdPregunta;
END
