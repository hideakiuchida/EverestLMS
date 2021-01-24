CREATE PROCEDURE [dbo].[UpdateLeccion]
	@IdLeccion int,
	@Nombre varchar(200) = NULL,
	@Descripcion varchar(max) = NULL,
	@ContenidoHTML TEXT = NULL,
	@Puntaje int = NULL,
	@NumeroOrden int = NULL,
	@IdCurso int = NULL
AS
BEGIN
	UPDATE Leccion 
	SET Nombre = CASE WHEN @Nombre IS NULL THEN Nombre ELSE @Nombre END,
	Descripcion = CASE WHEN @Descripcion IS NULL THEN Nombre ELSE @Descripcion END,
	ContenidoHTML = CASE WHEN @ContenidoHTML IS NULL THEN ContenidoHTML ELSE @ContenidoHTML END,
	Puntaje = CASE WHEN @Puntaje IS NULL THEN Puntaje ELSE @Puntaje END,
	--NumeroOrden = CASE WHEN @NumeroOrden IS NULL THEN NumeroOrden ELSE @NumeroOrden END,
	IdCurso = CASE WHEN @IdCurso IS NULL THEN IdCurso ELSE @IdCurso END
    WHERE IdLeccion = @IdLeccion;
	SELECT @@ROWCOUNT;
END
