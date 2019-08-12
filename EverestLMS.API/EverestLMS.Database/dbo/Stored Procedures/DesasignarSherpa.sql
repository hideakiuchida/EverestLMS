CREATE PROCEDURE [dbo].[DesasignarSherpa]
	@IdEscalador INT
AS
BEGIN
	DECLARE @Success BIT = 0;
	IF NOT EXISTS (SELECT 1 FROM [Participante] WHERE [IdParticipante] = @IdEscalador)
	BEGIN
		SELECT @Success;
	END
	ELSE
	BEGIN
		UPDATE [Participante]
		SET [idSherpa] = NULL
		WHERE [IdParticipante] = @IdEscalador;

		IF(@@ROWCOUNT > 0)
			SET @Success = 1;
		SELECT @Success;
	END
END
