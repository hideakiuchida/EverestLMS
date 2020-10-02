CREATE PROCEDURE [dbo].[UpdateRespuestaDelExamen]
(
     @IdExamen INT,
     @IdPregunta INT,
     @IdRespuesta INT NULL,
     @DescripcionRespuesta VARCHAR(2000),
     @MarcoCorrecto BIT,
	 @Id INT
)
AS
BEGIN
SET NOCOUNT ON;
	UPDATE [dbo].[RespuestaEscalador]
    SET [IdRespuesta] = @IdRespuesta
        ,[DescripcionRespuesta] = @DescripcionRespuesta
        ,[MarcoCorrecto] = @MarcoCorrecto
    WHERE [Id] = @Id AND [IdExamen] = @IdExamen
	SELECT @@ROWCOUNT;
END;