CREATE PROCEDURE [dbo].[CreateCloudinaryFile]
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
INSERT INTO [dbo].[CloudinaryFile]
           ([Descripcion]
           ,[IdPublico]
           ,[Url]
           ,[FechaCreacion]
           ,[IdCurso]
		   ,[IdPregunta]
		   ,[IdRespuesta]
		   ,[IdUsuario]
		   ,[IdLeccion])
     VALUES
           (@Descripcion
           ,@IdPublico
           ,@Url
           ,GETDATE()
           ,@IdCurso
		   ,@IdPregunta
		   ,@IdRespuesta
		   ,@IdUsuario
		   ,@IdLeccion);
SELECT SCOPE_IDENTITY();
END
