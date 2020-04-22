CREATE PROCEDURE [dbo].[DeleteCriterioAceptacion]
	@IdCalendario int,
	@IdCriterioAceptacion int
AS
BEGIN
	DELETE FROM [dbo].[CriterioAceptacion] WHERE IdCalendario = @IdCalendario AND IdCriterioAceptacion = @IdCriterioAceptacion;
	SELECT @@ROWCOUNT;
END


