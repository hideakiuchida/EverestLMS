CREATE PROCEDURE [dbo].[GetPreguntas]
	@IdLeccion int
AS
BEGIN
	SELECT [IdPregunta], [Descripcion], [Imagen], [IdLeccion]
	FROM [Pregunta]
	WHERE [IdLeccion] = @IdLeccion;
END