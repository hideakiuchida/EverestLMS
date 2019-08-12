CREATE TABLE [dbo].[PrediccionRatingCurso] (
    [idPrediccionRatingCurso] INT IDENTITY (1, 1) NOT NULL,
    [Rating]                  INT NOT NULL,
    [IdParticipante]          INT NOT NULL,
    [IdCurso]                 INT NOT NULL,
    PRIMARY KEY CLUSTERED ([idPrediccionRatingCurso] ASC),
	CONSTRAINT [FK_PrediccionRatingCurso_Participante] FOREIGN KEY ([IdParticipante]) REFERENCES [Participante]([IdParticipante]) ON DELETE CASCADE,
	CONSTRAINT [FK_PrediccionRatingCurso_Curso] FOREIGN KEY ([IdCurso]) REFERENCES [Curso]([IdCurso]) 
);

