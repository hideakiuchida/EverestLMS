CREATE PROCEDURE [dbo].[GetCursosPredictionByParticipant]
(
 @Id INT
)
AS
BEGIN
SET NOCOUNT ON;
	SELECT c.IdCurso, c.Nombre, c.Descripcion, c.Dificultad, c.Idioma, c.Puntaje, c.Imagen, c.Autor, p.Rating 
    FROM prediccionratingcurso p 
    INNER JOIN curso c ON p.IdCurso = c.IdCurso
    WHERE p.IdParticipante = @Id;
END;
