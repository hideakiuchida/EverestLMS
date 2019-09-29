CREATE PROCEDURE [dbo].[CreateLeccionMaterial]
	@Titulo varchar(100),
	@ContenidoTexto text,
	@IdPresentacion varchar(500),
	@IdTipoContenido int,
	@IdLeccion int
AS
BEGIN
	INSERT INTO [dbo].[LeccionMaterial]
           ([Titulo]
           ,[ContenidoTexto]
           ,[IdPresentacion]
           ,[IdTipoContenido]
           ,[IdLeccion])
     VALUES
           (@Titulo
           ,@ContenidoTexto
           ,@IdPresentacion
           ,@IdTipoContenido
           ,@IdLeccion)
	SELECT SCOPE_IDENTITY();
END
