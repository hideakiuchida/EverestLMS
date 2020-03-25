CREATE TABLE [dbo].[Usuario]
(
	[IdUsuario] INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
	[UsuarioKey] VARCHAR(1000) NOT NULL,
	[Username] VARCHAR(50) UNIQUE NOT NULL,
	[PasswordSalt] VARBINARY(MAX) NOT NULL,
	[PasswordHash] VARBINARY(MAX) NOT NULL,
	[FechaCreacion] DATETIME NOT NULL,
	[Activo] BIT NOT NULL,
	[IdRol] INT NOT NULL,
	[IdParticipante] INT NULL,
	CONSTRAINT [FK_Usuario_Rol] FOREIGN KEY ([IdRol]) REFERENCES [Rol]([IdRol]),
	CONSTRAINT [FK_Usuario_Participante] FOREIGN KEY ([IdParticipante]) REFERENCES [Participante]([IdParticipante]) ON DELETE CASCADE
)
