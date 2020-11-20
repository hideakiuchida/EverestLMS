CREATE PROCEDURE [dbo].[DeleteCloudinaryFile]
	@IdCloudinaryFile INT,
	@IdCurso INT NULL,
	@IdPregunta INT NULL,
	@IdRespuesta INT NULL,
	@IdUsuario INT NULL,
	@IdLeccion INT NULL
AS
BEGIN
	DELETE FROM  [dbo].[CloudinaryFile]
	WHERE IdCloudinaryFile = @IdCloudinaryFile 
	AND (@IdCurso IS NULL OR IdCurso = @IdCurso)
	AND (@IdPregunta IS NULL OR IdPregunta = @IdPregunta)
	AND (@IdRespuesta IS NULL OR IdRespuesta = @IdRespuesta)
	AND (@IdUsuario IS NULL OR IdUsuario = @IdUsuario)
	AND (@IdLeccion IS NULL OR IdUsuario = @IdLeccion);
	SELECT @@ROWCOUNT;
END

