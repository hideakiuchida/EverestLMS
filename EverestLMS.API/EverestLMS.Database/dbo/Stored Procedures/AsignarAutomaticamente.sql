CREATE PROCEDURE [dbo].[AsignarAutomaticamente]
	@IdSherpa INT,
	@IdEscaladores [dbo].[Ids] READONLY
AS
BEGIN
	DECLARE @Success BIT = 0;
	IF NOT EXISTS (SELECT 1 FROM [Participante] WHERE [IdParticipante] IN (SELECT [Id] FROM @IdEscaladores))
	BEGIN
		SELECT @Success;
	END
	ELSE IF NOT EXISTS (SELECT 1 FROM [Participante] WHERE [IdParticipante] = @IdSherpa)
	BEGIN
		SELECT @Success;
	END
	ELSE
	BEGIN
		UPDATE [Participante]
		SET [idSherpa] = @IdSherpa
		WHERE [IdParticipante] IN (SELECT [Id] FROM @IdEscaladores);

		IF(@@ROWCOUNT > 0)
			SET @Success = 1;
		SELECT @Success;
	END
END