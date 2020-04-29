CREATE PROCEDURE [dbo].[UpdateRespuesta]
    @IdRespuesta int,
	@Descripcion varchar(2000),
	@EsCorrecto bit,
	@IdPregunta int
AS
BEGIN

UPDATE [dbo].[Respuesta]
SET [Descripcion] = @Descripcion,
    [EsCorrecto] = @EsCorrecto,
    [IdPregunta] = @IdPregunta
WHERE [IdRespuesta] = @IdRespuesta;
SELECT @@ROWCOUNT;

END
