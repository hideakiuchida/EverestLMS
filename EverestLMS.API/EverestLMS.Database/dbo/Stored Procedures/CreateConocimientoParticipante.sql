CREATE PROCEDURE [dbo].[CreateConocimientoParticipante] 
(
 @IdConocimiento INT, 
 @IdParticipante INT
)
AS
BEGIN
	SET NOCOUNT ON;
	INSERT INTO conocimientoparticipante
	(IdConocimiento,
	IdParticipante)
	VALUES
	(@IdConocimiento,
	@IdParticipante);
	
	SELECT SCOPE_IDENTITY();
END;
