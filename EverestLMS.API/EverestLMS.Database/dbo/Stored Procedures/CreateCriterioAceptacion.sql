CREATE PROCEDURE [dbo].[CreateCriterioAceptacion]
(
 @Descripcion VARCHAR(1000), 
 @Medida VARCHAR(20),
 @Valor DECIMAL(10,2),
 @IdCalendario INT
)
AS
BEGIN
SET NOCOUNT ON;
	INSERT INTO [dbo].[CriterioAceptacion] (Descripcion, Medida, Valor, IdCalendario) 
    VALUES (@Descripcion, @Medida, @Valor, @IdCalendario);
	SELECT SCOPE_IDENTITY();
END;
