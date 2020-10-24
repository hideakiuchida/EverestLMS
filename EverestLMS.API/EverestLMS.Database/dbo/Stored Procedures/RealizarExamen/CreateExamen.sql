CREATE PROCEDURE [dbo].[CreateExamen]
(
	 @UsuarioKey VARCHAR(1000),
	 @IdCurso INT,
	 @IdLeccion INT NULL,
	 @Nota DECIMAL(4,2),
	 @VidasRestante INT,
	 @NumeroPreguntaActual INT,
	 @TiempoRestante INT
)
AS
BEGIN
SET NOCOUNT ON;
	INSERT INTO Examen(UsuarioKey, IdCurso, IdLeccion, Nota, VidasRestante, NumeroPreguntaActual, TiempoRestante) 
    VALUES (@UsuarioKey, @IdCurso, @IdLeccion, @Nota, @VidasRestante, @NumeroPreguntaActual, @TiempoRestante);
	SELECT SCOPE_IDENTITY();
END;

