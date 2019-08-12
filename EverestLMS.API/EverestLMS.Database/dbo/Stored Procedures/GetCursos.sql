CREATE PROCEDURE [dbo].[GetCursos]
(
 @IdNivel INT = NULL, 
 @IdLineaCarrera INT = NULL
)
AS
BEGIN
SET NOCOUNT ON;
	SELECT c.IdCurso, c.Nombre, c.Descripcion, c.Dificultad, c.Idioma, c.Puntaje, c.Imagen, c.Autor 
    FROM curso c 
    INNER JOIN etapa e ON c.IdEtapa = e.IdEtapa
    WHERE (@IdNivel IS NULL  OR e.IdNivel = @IdNivel)
    AND (@IdLineaCarrera IS NULL OR e.IdLineaCarrera = @IdLineaCarrera);
END;
