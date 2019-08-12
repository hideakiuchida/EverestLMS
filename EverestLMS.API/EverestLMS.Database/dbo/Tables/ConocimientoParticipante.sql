CREATE TABLE [dbo].[ConocimientoParticipante] (
    [IdConocimientoParticipante] INT IDENTITY (1, 1) NOT NULL,
    [IdConocimiento]             INT NOT NULL,
    [IdParticipante]             INT NOT NULL,
    PRIMARY KEY CLUSTERED ([IdConocimientoParticipante] ASC),
	CONSTRAINT [FK_ConocimientoParticipante_Conocimiento] FOREIGN KEY ([IdConocimiento]) REFERENCES [Conocimiento]([IdConocimiento]) ON DELETE CASCADE,
	CONSTRAINT [FK_ConocimientoParticipante_Participante] FOREIGN KEY ([IdParticipante]) REFERENCES [Participante]([IdParticipante]) ON DELETE CASCADE
);

