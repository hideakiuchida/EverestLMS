CREATE PROCEDURE [dbo].[CreateRespuesta]
	@Descripcion varchar(200),
	@EsCorrecto bit,
	@IdPregunta int
AS
BEGIN

INSERT INTO [dbo].[Respuesta]
           ([Descripcion]
           ,[EsCorrecto]
           ,[IdPregunta])
     VALUES
           (@Descripcion
           ,@EsCorrecto
		   ,@IdPregunta);
SELECT SCOPE_IDENTITY();
END
