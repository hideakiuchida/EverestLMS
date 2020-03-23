CREATE TABLE [dbo].[Usuario]
(
	[IdUsuario] INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
	[UsuarioKey] VARCHAR(1000) NOT NULL,
	[Username] VARCHAR(50) UNIQUE NOT NULL,
	[PasswordSalt] VARCHAR(1000) NOT NULL,
	[PasswordHash] VARCHAR(1000) NOT NULL,
	[FechaCreacion] DATETIME NOT NULL,
	[Activo] BIT NOT NULL,
	[IdRol] INT NOT NULL,
	[IdParticipante] INT NULL,
	CONSTRAINT [FK_Usuario_Rol] FOREIGN KEY ([IdRol]) REFERENCES [Rol]([IdRol]),
	CONSTRAINT [FK_Usuario_Participante] FOREIGN KEY ([IdRol]) REFERENCES [Participante]([IdParticipante]) ON DELETE CASCADE
)
