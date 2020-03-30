CREATE PROCEDURE [dbo].[GetCursosPredictionByParticipante]
(
 @Id VARCHAR(1000),
 @IdEtapa INT = NULL,
 @IdIdioma INT = NULL
)
AS
BEGIN
	DECLARE @IdParticipante INT = (SELECT u.IdParticipante FROM Usuario u WHERE u.UsuarioKey = @Id);
	SELECT c.IdCurso, 
	c.Nombre, 
	c.Descripcion, 
	c.IdDificultad, 
	c.Idioma, 
	c.Puntaje, 
	(SELECT TOP 1 [Url] FROM CloudinaryFile cf INNER JOIN Curso cu ON cf.IdCurso = cu.IdCurso WHERE cu.IdCurso = c.IdCurso) AS Imagen, 
	c.Autor, 
	p.Rating,
	e.Nombre as NombreEtapa,
	c.IdEtapa
    FROM prediccionratingcurso p 
    INNER JOIN curso c ON p.IdCurso = c.IdCurso
	INNER JOIN etapa e ON e.IdEtapa = c.IdEtapa
    WHERE p.IdParticipante = @IdParticipante
	AND (@IdEtapa IS NULL OR e.IdEtapa = @IdEtapa)
	AND (@IdIdioma IS NULL OR Idioma = @IdIdioma);
END;
