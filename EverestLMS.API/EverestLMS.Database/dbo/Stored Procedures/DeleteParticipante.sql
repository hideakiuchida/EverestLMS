CREATE PROCEDURE [dbo].[DeleteParticipante]
	@IdParticipante INT
AS
BEGIN 
	DELETE FROM Participante WHERE IdParticipante = @IdParticipante;
	SELECT @@ROWCOUNT;
END
