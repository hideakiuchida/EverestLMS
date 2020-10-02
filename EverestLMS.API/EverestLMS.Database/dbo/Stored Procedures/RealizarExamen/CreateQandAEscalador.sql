CREATE PROCEDURE [dbo].[CreateQandAEscalador]
(
	 @IdPregunta INT, 
	 @DescripcionPregunta VARCHAR(2000),
	 @IdRespuesta INT,
	 @DescripcionRespuesta VARCHAR(2000),
	 @MarcoCorrecto BIT NULL,
	 @IdExamen INT
)
AS
BEGIN
SET NOCOUNT ON;
	INSERT INTO RespuestaEscalador(IdPregunta, DescripcionPregunta, IdRespuesta, DescripcionRespuesta, MarcoCorrecto, IdExamen) 
    VALUES (@IdPregunta, @DescripcionPregunta, @IdRespuesta, @DescripcionRespuesta, @MarcoCorrecto, @IdExamen);
	SELECT SCOPE_IDENTITY();
END;
