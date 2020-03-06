CREATE PROCEDURE [dbo].[GetLecciones]
(
 @IdNivel INT = NULL, 
 @IdLineaCarrera INT = NULL,
 @IdEtapa INT = NULL,
 @IdCurso INT = NULL,
 @Search VARCHAR(100) = NULL
)
AS
BEGIN
SET NOCOUNT ON;
	SELECT le.IdLeccion, 
	le.Nombre, 
	le.Descripcion, 
	le.IdCurso, 
	c.Descripcion as CursoDescripcion,
	i.Descripcion as IdiomaDescripcion,
	e.Descripcion as EtapaDescripcion,
	e.Nombre as NombreEtapa,
	n.Descripcion as NivelDescripcion,
	l.Descripcion as LineaCarreraDescripcion,
	le.Puntaje,
	d.Descripcion as DificultadDescripcion,
	c.Autor,
	e.IdEtapa
	FROM Leccion le 
	INNER JOIN curso c ON le.IdCurso = c.IdCurso
    INNER JOIN etapa e ON c.IdEtapa = e.IdEtapa
	LEFT JOIN Dificultad d ON d.IdDificultad = c.IdDificultad
	LEFT JOIN Idioma i ON i.IdIdioma = c.Idioma
	LEFT JOIN LineaCarrera l ON l.IdLineaCarrera = e.IdLineaCarrera
	LEFT JOIN Nivel n ON n.IdNivel = e.IdNivel
    WHERE (@IdNivel IS NULL OR e.IdNivel = @IdNivel)
    AND (@IdLineaCarrera IS NULL OR e.IdLineaCarrera = @IdLineaCarrera)
	AND (@IdEtapa IS NULL  OR e.IdEtapa = @IdEtapa)
	AND (@IdCurso IS NULL  OR c.IdCurso = @IdCurso)
	AND (@Search IS NULL OR le.Nombre LIKE '%' + @Search + '%');
END;

