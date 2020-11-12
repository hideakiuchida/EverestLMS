CREATE PROCEDURE [dbo].[ActualizarPuntaje]
	@Id VARCHAR(1000),
	@Puntaje INT
AS
BEGIN
	DECLARE @Success BIT = 0;
	DECLARE @IdPartiEscalador INT = (SELECT u.IdParticipante FROM Usuario u WHERE u.UsuarioKey = @Id);
	IF NOT EXISTS (SELECT 1 FROM [Participante] WHERE [IdParticipante] = @IdPartiEscalador)
	BEGIN
		SELECT @Success;
	END
	ELSE
	BEGIN
		UPDATE [Participante]
		SET [Puntaje] = @Puntaje
		WHERE [IdParticipante] = @IdPartiEscalador;

		IF(@@ROWCOUNT > 0)
			SET @Success = 1;
		SELECT @Success;
	END
END

