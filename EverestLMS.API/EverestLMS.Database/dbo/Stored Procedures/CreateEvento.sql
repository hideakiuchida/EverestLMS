CREATE PROCEDURE [dbo].[CreateEvento]
(
 @Titulo VARCHAR(200), 
 @Descripcion VARCHAR(500), 
 @FechaInicio DATETIME,
 @FechaFinal DATETIME,
 @ColorPrimario VARCHAR(20),
 @ColorSecundario VARCHAR(20),
 @IdCalendario INT
)
AS
BEGIN
SET NOCOUNT ON;
	INSERT INTO Evento (Titulo, Descripcion, FechaInicio, FechaFinal, ColorPrimario, ColorSecundario, IdCalendario) 
    VALUES (@Titulo, @Descripcion, @FechaInicio, @FechaFinal, @ColorPrimario, @ColorSecundario, @IdCalendario);
	SELECT SCOPE_IDENTITY();
END;
