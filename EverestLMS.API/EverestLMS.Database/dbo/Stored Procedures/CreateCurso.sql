CREATE PROCEDURE [dbo].[CreateCurso]
(
 @Nombre VARCHAR(200), 
 @Descripcion VARCHAR(500), 
 @IdDificultad INT,
 @Idioma INT,
 @Puntaje INT,
 @Imagen VARCHAR(200),
 @Autor VARCHAR(200),
 @IdEtapa INT
)
AS
BEGIN
SET NOCOUNT ON;
	DECLARE @IdCurso INT;
	SET @IdCurso = (SELECT TOP 1 IdCurso FROM curso ORDER BY IdCurso Desc) + 1;
	INSERT INTO curso (IdCurso,Nombre,Descripcion,IdDificultad, Idioma,Puntaje,Imagen,Autor,FechaCreacion,IdEtapa)
    VALUES (@IdCurso, @Nombre, @Descripcion, @IdDificultad, @Idioma, @Puntaje, @Imagen, @Autor, GETDATE(), @IdEtapa);
	SELECT @IdCurso;
END;
