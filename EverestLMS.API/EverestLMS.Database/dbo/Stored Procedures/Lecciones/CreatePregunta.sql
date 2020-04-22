CREATE PROCEDURE [dbo].[CreatePregunta]
	@Descripcion varchar(200),
	@Imagen varchar(MAX),
	@IdLeccion int
AS
BEGIN

INSERT INTO [dbo].[Pregunta]
           ([Descripcion]
           ,[Imagen]
           ,[IdLeccion])
     VALUES
           (@Descripcion
           ,@Imagen
		   ,@IdLeccion);
SELECT SCOPE_IDENTITY();
END

