CREATE PROCEDURE [dbo].[GetCursosByParticipante]
(
 @Id INT,
 @IdEtapa INT = NULL,
 @IdIdioma INT = NULL
)
AS
BEGIN
SET NOCOUNT ON;
	SELECT c.IdCurso, 
	c.Nombre, 
	c.Descripcion, 
	c.IdDificultad, 
	c.Idioma, 
	c.Puntaje, 
	(SELECT TOP 1 [Url] FROM CloudinaryFile cf INNER JOIN Curso cu ON cf.IdCurso = cu.IdCurso WHERE cu.IdCurso = c.IdCurso) AS Imagen, 
	c.Autor, 
	e.Nombre as NombreEtapa,
	c.IdEtapa
    FROM curso c 
	INNER JOIN Etapa e ON e.IdEtapa = c.IdEtapa
	INNER JOIN Participante p ON p.IdLineaCarrera = e.IdLineaCarrera AND p.IdNivel = e.IdNivel
    WHERE p.IdParticipante = @Id
	AND (@IdEtapa IS NULL OR e.IdEtapa = @IdEtapa)
	AND (@IdIdioma IS NULL OR c.Idioma = @IdIdioma);
END;
