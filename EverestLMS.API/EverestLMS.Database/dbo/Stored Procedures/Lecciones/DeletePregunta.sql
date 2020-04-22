CREATE PROCEDURE [dbo].[DeletePregunta]
	@IdPregunta int
AS
BEGIN
 DELETE FROM [dbo].[Pregunta]
 WHERE IdPregunta = @IdPregunta;
 SELECT @@ROWCOUNT;
END
