CREATE PROCEDURE [dbo].[DesasignarSherpa]
	@IdEscalador VARCHAR(1000)
AS
BEGIN
	DECLARE @IdParti INT = (SELECT u.IdParticipante FROM Usuario u WHERE u.UsuarioKey = @IdEscalador);
	DECLARE @Success BIT = 0;
	IF NOT EXISTS (SELECT 1 FROM [Participante] WHERE [IdParticipante] = @IdParti)
	BEGIN
		SELECT @Success;
	END
	ELSE
	BEGIN
		UPDATE [Participante]
		SET [IdSherpa] = NULL
		WHERE [IdParticipante] = @IdParti;

		IF(@@ROWCOUNT > 0)
			SET @Success = 1;
		SELECT @Success;
	END
END
