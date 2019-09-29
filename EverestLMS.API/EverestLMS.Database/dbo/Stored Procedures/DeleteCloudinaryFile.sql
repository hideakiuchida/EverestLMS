CREATE PROCEDURE [dbo].[DeleteCloudinaryFile]
	@IdCloudinaryFile INT,
	@IdReferencia INT
AS
BEGIN
	DELETE FROM  [dbo].[CloudinaryFile]
	WHERE IdCloudinaryFile = @IdCloudinaryFile 
	AND (@IdReferencia IS NULL OR IdReferencia = @IdReferencia);
	SELECT @@ROWCOUNT;
END

