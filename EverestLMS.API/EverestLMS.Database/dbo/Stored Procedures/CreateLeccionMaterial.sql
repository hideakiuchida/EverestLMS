CREATE PROCEDURE [dbo].[CreateLeccionMaterial]
	@Titulo varchar(100),
	@ContenidoTexto text = NULL,
	@IdPublico varchar(100) = NULL,
	@Url varchar(500)  = NULL,	
	@IdPresentacion varchar(500) = NULL,
	@IdTipoContenido int,
	@IdLeccion int
AS
BEGIN
	INSERT INTO [dbo].[LeccionMaterial]
           ([Titulo]
           ,[ContenidoTexto]
		   ,[IdPublico]
		   ,[Url]
           ,[IdPresentacion]
           ,[IdTipoContenido]
           ,[IdLeccion])
     VALUES
           (@Titulo
           ,@ContenidoTexto
		   ,@IdPublico
		   ,@Url
           ,@IdPresentacion
           ,@IdTipoContenido
           ,@IdLeccion)
	SELECT SCOPE_IDENTITY();
END
