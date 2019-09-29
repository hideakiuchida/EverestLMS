CREATE PROCEDURE [dbo].[CreateCloudinaryFile]
	@Descripcion varchar(100),
	@IdPublico varchar(100),
	@Url varchar(500),	
	@IdReferencia INT NULL
AS
BEGIN
INSERT INTO [dbo].[CloudinaryFile]
           ([Descripcion]
           ,[IdPublico]
           ,[Url]
           ,[FechaCreacion]
           ,[IdReferencia])
     VALUES
           (@Descripcion
           ,@IdPublico
           ,@Url
           ,GETDATE()
           ,@IdReferencia);
SELECT SCOPE_IDENTITY();
END
