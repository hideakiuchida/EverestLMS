CREATE PROCEDURE [dbo].[UpdatePregunta]
	@IdPregunta int,
	@Descripcion varchar(2000),
	@Imagen varchar(MAX),
	@IdLeccion int
AS
BEGIN

UPDATE [dbo].[Pregunta]
SET [Descripcion] = @Descripcion,
    [Imagen] = @Imagen,
    [IdLeccion] = @IdLeccion
WHERE [IdPregunta] = @IdPregunta;
SELECT @@ROWCOUNT;

END

