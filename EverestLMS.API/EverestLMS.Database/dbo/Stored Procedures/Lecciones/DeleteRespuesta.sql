CREATE PROCEDURE [dbo].[DeleteRespuesta]
	@IdRespuesta int
AS
BEGIN
 DELETE FROM [dbo].[Respuesta]
 WHERE IdRespuesta = @IdRespuesta;
 SELECT @@ROWCOUNT;
END

