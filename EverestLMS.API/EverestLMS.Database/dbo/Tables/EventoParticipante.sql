CREATE TABLE [dbo].[EventoParticipante] (
    [IdEventoParticipante] INT IDENTITY (1, 1) NOT NULL,
    [IdEvento]             INT NOT NULL,
    [IdParticipante]             INT NOT NULL,
    PRIMARY KEY CLUSTERED ([IdEventoParticipante] ASC),
	CONSTRAINT [FK_EventoParticipante_Conocimiento] FOREIGN KEY ([IdEvento]) REFERENCES [Evento]([IdEvento]) ON DELETE CASCADE,
	CONSTRAINT [FK_EventoParticipante_Participante] FOREIGN KEY ([IdParticipante]) REFERENCES [Participante]([IdParticipante]) ON DELETE CASCADE
);
