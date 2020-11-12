CREATE PROCEDURE [dbo].[CreateExamen]
(
	 @UsuarioKey VARCHAR(1000),
	 @IdEtapa INT,
	 @IdCurso INT,
	 @IdLeccion INT NULL,
	 @Nota DECIMAL(5,2),
	 @VidasRestante INT,
	 @NumeroPreguntaActual INT,
	 @TiempoRestante INT
)
AS
BEGIN
SET NOCOUNT ON;
	INSERT INTO Examen(UsuarioKey, IdEtapa, IdCurso, IdLeccion, Nota, VidasRestante, NumeroPreguntaActual, TiempoRestante) 
    VALUES (@UsuarioKey, @IdEtapa, @IdCurso, @IdLeccion, @Nota, @VidasRestante, @NumeroPreguntaActual, @TiempoRestante);
	SELECT SCOPE_IDENTITY();
END;

