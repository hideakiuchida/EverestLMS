CREATE PROCEDURE [dbo].[EditCloudinaryFile]
	@IdCloudinaryFile INT,
	@Descripcion varchar(100),
	@IdPublico varchar(100),
	@Url varchar(500),	
	@IdReferencia INT NULL
AS
BEGIN
	UPDATE  [dbo].[CloudinaryFile] 
	SET Descripcion = CASE WHEN @Descripcion IS NULL THEN Descripcion ELSE @Descripcion END,
	IdPublico = CASE WHEN @IdPublico IS NULL THEN IdPublico ELSE @IdPublico END, 
	[Url] = CASE WHEN @Url IS NULL THEN [Url] ELSE @Url END
    WHERE IdCloudinaryFile = @IdCloudinaryFile 
	AND (@IdReferencia IS NULL OR IdReferencia = @IdReferencia);
	SELECT @@ROWCOUNT;
END
