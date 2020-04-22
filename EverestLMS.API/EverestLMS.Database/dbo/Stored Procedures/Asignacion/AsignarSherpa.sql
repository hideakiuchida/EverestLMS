CREATE PROCEDURE [dbo].[AsignarSherpa]
	@IdEscalador VARCHAR(1000),
	@IdSherpa VARCHAR(1000)
AS
BEGIN
	DECLARE @Success BIT = 0;
	DECLARE @IdPartiEscalador INT = (SELECT u.IdParticipante FROM Usuario u WHERE u.UsuarioKey = @IdEscalador);
	DECLARE @IdPartiSherpa INT = (SELECT u.IdParticipante FROM Usuario u WHERE u.UsuarioKey = @IdSherpa);
	IF NOT EXISTS (SELECT 1 FROM [Participante] WHERE [IdParticipante] = @IdPartiEscalador)
	BEGIN
		SELECT @Success;
	END
	ELSE
	BEGIN
		UPDATE [Participante]
		SET [idSherpa] = @IdPartiSherpa
		WHERE [IdParticipante] = @IdPartiEscalador;

		IF(@@ROWCOUNT > 0)
			SET @Success = 1;
		SELECT @Success;
	END
END
