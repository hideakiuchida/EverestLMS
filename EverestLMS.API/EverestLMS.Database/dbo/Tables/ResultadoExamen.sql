CREATE TABLE [dbo].[ResultadoExamen]
(
	[IdResultadoExamen] INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
	[Resultado] DECIMAL(4,2) NOT NULL,
	[IdParticipante] INT NOT NULL,
	[IdCurso] INT NULL,
	[IdLeccion] INT NULL,
	CONSTRAINT [FK_ResultadoExamen_Escalador] FOREIGN KEY ([IdParticipante]) REFERENCES [Participante]([IdParticipante]),
	CONSTRAINT [FK_ResultadoExamen_Curso] FOREIGN KEY ([IdCurso]) REFERENCES [Curso]([IdCurso]),
	CONSTRAINT [FK_ResultadoExamen_Leccion] FOREIGN KEY ([IdLeccion]) REFERENCES [Leccion]([IdLeccion])

)
