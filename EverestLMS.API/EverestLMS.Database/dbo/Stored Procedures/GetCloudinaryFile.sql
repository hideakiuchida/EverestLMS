CREATE PROCEDURE [dbo].[GetCloudinaryFile]
	@IdCloudinaryFile INT,
	@IdReferencia INT NULL
AS
BEGIN
SELECT [IdCloudinaryFile]
      ,[Descripcion]
      ,[IdPublico]
      ,[Url]
      ,[FechaCreacion]
      ,[IdReferencia]
  FROM [dbo].[CloudinaryFile]
  WHERE IdCloudinaryFile = @IdCloudinaryFile 
	AND (@IdReferencia IS NULL OR IdReferencia = @IdReferencia);
END


