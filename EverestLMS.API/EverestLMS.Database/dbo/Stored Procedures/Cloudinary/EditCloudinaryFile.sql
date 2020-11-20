CREATE PROCEDURE [dbo].[EditCloudinaryFile]
	@IdCloudinaryFile INT,
	@Descripcion varchar(100),
	@IdPublico varchar(100),
	@Url varchar(500),	
	@IdCurso INT NULL,
	@IdPregunta INT NULL,
	@IdRespuesta INT NULL,
	@IdUsuario INT NULL,
	@IdLeccion INT NULL
AS
BEGIN
	UPDATE  [dbo].[CloudinaryFile] 
	SET Descripcion = CASE WHEN @Descripcion IS NULL THEN Descripcion ELSE @Descripcion END,
	IdPublico = CASE WHEN @IdPublico IS NULL THEN IdPublico ELSE @IdPublico END, 
	[Url] = CASE WHEN @Url IS NULL THEN [Url] ELSE @Url END
    WHERE IdCloudinaryFile = @IdCloudinaryFile 
	AND (@IdCurso IS NULL OR IdCurso = @IdCurso)
	AND (@IdPregunta IS NULL OR IdPregunta = @IdPregunta)
	AND (@IdRespuesta IS NULL OR IdRespuesta = @IdRespuesta)
	AND (@IdUsuario IS NULL OR IdUsuario = @IdUsuario)
	AND (@IdLeccion IS NULL OR IdLeccion = @IdLeccion);
	SELECT @@ROWCOUNT;
END
