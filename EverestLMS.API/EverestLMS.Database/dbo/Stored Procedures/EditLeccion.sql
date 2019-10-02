CREATE PROCEDURE [dbo].[EditLeccion]
	@IdLeccion int,
	@Nombre varchar(200),
	@Descripcion varchar(max),
	@Puntaje int,
	@NumeroOrden int,
	@IdCurso int
AS
BEGIN
	UPDATE Leccion 
	SET Nombre = CASE WHEN @Nombre IS NULL THEN Nombre ELSE @Nombre END,
	Descripcion = CASE WHEN @Descripcion IS NULL THEN Nombre ELSE @Descripcion END,
	Puntaje = CASE WHEN @Puntaje IS NULL THEN Puntaje ELSE @Puntaje END,
	NumeroOrden = CASE WHEN @NumeroOrden IS NULL THEN NumeroOrden ELSE @NumeroOrden END
    WHERE IdCurso = @IdCurso AND IdLeccion = @IdLeccion;
	SELECT @@ROWCOUNT;
END
