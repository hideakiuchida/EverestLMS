CREATE PROCEDURE [dbo].[DeleteEvento]
	@IdCalendario int,
	@IdEvento int
AS
BEGIN
	DELETE FROM [dbo].[Evento] WHERE IdCalendario = @IdCalendario AND IdEvento = @IdEvento;
	SELECT @@ROWCOUNT;
END
