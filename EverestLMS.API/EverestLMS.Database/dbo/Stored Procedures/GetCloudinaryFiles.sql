CREATE PROCEDURE [dbo].[GetCloudinaryFiles]
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
  WHERE (@IdReferencia IS NULL OR IdReferencia = @IdReferencia);
END
