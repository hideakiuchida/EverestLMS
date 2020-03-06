CREATE PROCEDURE [dbo].[EditCurso]
(
 @IdCurso INT,
 @Nombre VARCHAR(200) NULL, 
 @Descripcion VARCHAR(500) NULL, 
 @IdDificultad INT NULL,
 @Idioma INT NULL,
 @Puntaje INT NULL,
 @Imagen VARCHAR(200) NULL,
 @Autor VARCHAR(200) NULL,
 @IdEtapa INT NULL
)
AS
BEGIN
SET NOCOUNT ON;
	UPDATE curso 
	SET Nombre = CASE WHEN @Nombre IS NULL THEN Nombre ELSE @Nombre END,
	Descripcion = CASE WHEN @Descripcion IS NULL THEN Nombre ELSE @Descripcion END,
	IdDificultad = CASE WHEN @IdDificultad IS NULL THEN Nombre ELSE @IdDificultad END, 
	Idioma = CASE WHEN @Idioma IS NULL THEN Idioma ELSE @Idioma END,
	Puntaje = CASE WHEN @Puntaje IS NULL THEN Puntaje ELSE @Puntaje END,
	Imagen = CASE WHEN @Imagen IS NULL THEN Imagen ELSE @Imagen END,
	Autor = CASE WHEN @Autor IS NULL THEN Autor ELSE @Autor END,
    IdEtapa = CASE WHEN @IdEtapa IS NULL THEN IdEtapa ELSE @IdEtapa END
    WHERE IdCurso = @IdCurso;
	SELECT @@ROWCOUNT;
END;
