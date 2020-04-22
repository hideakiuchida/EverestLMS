CREATE PROCEDURE [dbo].[DesasignarSherpaAutomaticamente]
AS
BEGIN
	DECLARE @Success BIT = 0;
	BEGIN
		UPDATE [Participante]
		SET [idSherpa] = NULL;

		IF(@@ROWCOUNT > 0)
			SET @Success = 1;
		SELECT @Success;
	END
END
