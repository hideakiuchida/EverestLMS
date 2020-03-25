CREATE TABLE [dbo].[Participante] (
    [IdParticipante]  INT            IDENTITY (1, 1) NOT NULL PRIMARY KEY,
    [Nombre]          VARCHAR (100)  NOT NULL,
    [Apellido]        VARCHAR (100)  NOT NULL,
    [Correo]          VARCHAR (100)  NOT NULL,
    [Genero]          VARCHAR (45)   NOT NULL,
    [FechaNacimiento] DATETIME		 NOT NULL,
    [AñosExperiencia] INT            NULL,
    [Calificacion]    DECIMAL (4,2) NULL,
    [Puntaje]         INT            NULL,
    [Photo]           VARCHAR (500)  NULL,
    [Activo]          INT            NOT NULL,
    [IdSherpa]        INT            NULL,
    [IdLineaCarrera]  INT            NOT NULL,
    [IdNivel]         INT            NOT NULL,
	[IdSede]          INT  NOT NULL,
	CONSTRAINT [FK_Participante_Sherpa] FOREIGN KEY ([IdSherpa]) REFERENCES [Participante]([IdParticipante]),
	CONSTRAINT [FK_Participante_Nivel] FOREIGN KEY ([IdNivel]) REFERENCES [Nivel]([IdNivel]) ON DELETE CASCADE,
	CONSTRAINT [FK_Participante_LineaCarrera] FOREIGN KEY ([IdLineaCarrera]) REFERENCES [LineaCarrera]([IdLineaCarrera]) ON DELETE CASCADE,
	CONSTRAINT [FK_Participante_Sede] FOREIGN KEY ([IdSede]) REFERENCES [Sede]([IdSede]) ON DELETE CASCADE
);

