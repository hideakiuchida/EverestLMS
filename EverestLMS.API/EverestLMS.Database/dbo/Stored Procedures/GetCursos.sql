CREATE PROCEDURE [dbo].[GetCursos]
(
 @IdNivel INT = NULL, 
 @IdLineaCarrera INT = NULL,
 @IdEtapa INT = NULL,
 @Search VARCHAR(100) = NULL
)
AS
BEGIN
SET NOCOUNT ON;
	SELECT c.IdCurso, 
	c.Nombre, 
	c.Descripcion, 
	e.Descripcion as DescripcionEtapa, 
	e.Nombre as NombreEtapa,
	d.Descripcion as DificultadDescripcion, 
	c.IdEtapa,
	i.Descripcion as IdiomaDescripcion, 
	l.Descripcion as LineaCarreraDescripcion,
	n.Descripcion as NivelDescripcion, 
	c.IdDificultad, 
	c.Idioma, 
	c.Puntaje, 
	(SELECT TOP 1 [Url] FROM CloudinaryFile cf INNER JOIN Curso cu ON cf.IdCurso = cu.IdCurso WHERE cu.IdCurso = c.IdCurso) AS Imagen, 
	c.Autor 
    FROM curso c 
    INNER JOIN etapa e ON c.IdEtapa = e.IdEtapa
	LEFT JOIN Dificultad d ON d.IdDificultad = c.IdDificultad
	LEFT JOIN Idioma i ON i.IdIdioma = c.Idioma
	LEFT JOIN LineaCarrera l ON l.IdLineaCarrera = e.IdLineaCarrera
	LEFT JOIN Nivel n ON n.IdNivel = e.IdNivel
    WHERE (@IdNivel IS NULL  OR e.IdNivel = @IdNivel)
    AND (@IdLineaCarrera IS NULL OR e.IdLineaCarrera = @IdLineaCarrera)
	AND (@IdEtapa IS NULL  OR e.IdEtapa = @IdEtapa)
	AND (@Search IS NULL OR c.Nombre LIKE '%' + @Search + '%');;
END;
