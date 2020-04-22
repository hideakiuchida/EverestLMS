CREATE PROCEDURE [dbo].[CreatePredictionCurso]
(
 @Rating INT, 
 @IdParticipante INT, 
 @IdCurso INT
)
AS
BEGIN
SET NOCOUNT ON;
	INSERT INTO PrediccionRatingCurso(Rating, IdParticipante, IdCurso) 
    VALUES (@Rating, @IdParticipante, @IdCurso);
	SELECT SCOPE_IDENTITY();
END;
