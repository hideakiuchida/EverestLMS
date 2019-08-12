CREATE TABLE [dbo].[RatingCurso] (
    [IdRatingCurso]  INT IDENTITY (1, 1) NOT NULL,
    [Rating]         INT NOT NULL,
    [IdParticipante] INT NOT NULL,
    [IdCurso]        INT NOT NULL,
	CONSTRAINT [FK_RatingCurso_Participante] FOREIGN KEY ([IdParticipante]) REFERENCES [Participante]([IdParticipante]) ON DELETE CASCADE,
	CONSTRAINT [FK_RatingCurso_Curso] FOREIGN KEY ([IdCurso]) REFERENCES [Curso]([IdCurso])
);

