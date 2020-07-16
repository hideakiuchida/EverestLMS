CREATE PROCEDURE [dbo].[GetCurso]
	@IdEtapa int,
	@IdCurso int
AS
BEGIN
	SELECT c.IdCurso, 
	c.Nombre, 
	c.Descripcion, 
	c.IdEtapa,
	c.IdDificultad,
	c.Idioma,
	c.Puntaje, 
	(SELECT TOP 1 [Url] FROM CloudinaryFile cf INNER JOIN Curso cu ON cf.IdCurso = cu.IdCurso WHERE cu.IdCurso = c.IdCurso) AS Imagen, 
	c.Autor, 
	e.IdLineaCarrera, 
	e.IdNivel,
	e.Nombre as NombreEtapa
    FROM curso c 
    INNER JOIN etapa e ON c.IdEtapa = e.IdEtapa
    WHERE c.IdCurso = @IdCurso AND e.IdEtapa = @IdEtapa;
END
