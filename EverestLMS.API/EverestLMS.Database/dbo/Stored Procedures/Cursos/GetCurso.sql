CREATE PROCEDURE [dbo].[GetCurso]
	@IdEtapa int,
	@IdCurso int
AS
BEGIN
	SELECT c.IdCurso, c.Nombre, c.Descripcion, c.IdEtapa,c.IdDificultad, c.Idioma, c.Puntaje, c.Imagen, c.Autor, e.IdLineaCarrera, e.IdNivel
    FROM curso c 
    INNER JOIN etapa e ON c.IdEtapa = e.IdEtapa
    WHERE c.IdCurso = @IdCurso AND e.IdEtapa = @IdEtapa;
END
