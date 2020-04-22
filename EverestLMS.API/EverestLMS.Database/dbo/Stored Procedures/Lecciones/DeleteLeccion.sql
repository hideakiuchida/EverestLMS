CREATE PROCEDURE [dbo].[DeleteLeccion]
	@IdLeccion int,
	@IdCurso int
AS
BEGIN
	DELETE FROM Leccion
    WHERE IdCurso = @IdCurso AND IdLeccion = @IdLeccion;
	SELECT @@ROWCOUNT;
END
