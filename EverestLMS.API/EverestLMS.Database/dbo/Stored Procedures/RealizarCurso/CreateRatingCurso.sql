CREATE PROCEDURE [dbo].[CreateRatingCurso]
(
 @Rating INT, 
 @IdParticipante INT, 
 @IdCurso INT
)
AS
BEGIN
SET NOCOUNT ON;
	INSERT INTO RatingCurso(Rating, IdParticipante, IdCurso) 
    VALUES (@Rating, @IdParticipante, @IdCurso);
	SELECT SCOPE_IDENTITY();
END;
