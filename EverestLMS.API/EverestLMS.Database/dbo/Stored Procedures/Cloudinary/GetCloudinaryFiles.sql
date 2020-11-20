CREATE PROCEDURE [dbo].[GetCloudinaryFiles]
	@IdCurso INT NULL,
	@IdPregunta INT NULL,
	@IdRespuesta INT NULL,
	@IdUsuario INT NULL,
	@IdLeccion INT NULL
AS
BEGIN
	SELECT [IdCloudinaryFile]
      ,[Descripcion]
      ,[IdPublico]
      ,[Url]
      ,[FechaCreacion]
      ,[IdCurso]
	  ,[IdPregunta]
	  ,[IdRespuesta]
	  ,[IdUsuario]
  FROM [dbo].[CloudinaryFile]
  WHERE (@IdCurso IS NULL OR IdCurso = @IdCurso)
	AND (@IdPregunta IS NULL OR IdPregunta = @IdPregunta)
	AND (@IdRespuesta IS NULL OR IdRespuesta = @IdRespuesta)
	AND (@IdUsuario IS NULL OR IdUsuario = @IdUsuario)
	AND (@IdLeccion IS NULL OR IdLeccion = @IdLeccion);
END
