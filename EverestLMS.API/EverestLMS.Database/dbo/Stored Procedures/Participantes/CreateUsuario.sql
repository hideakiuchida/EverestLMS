CREATE PROCEDURE [dbo].[CreateUsuario]
(
 @UsuarioKey VARCHAR(1000), 
 @Username VARCHAR(50),
 @PasswordSalt VARBINARY(MAX),
 @PasswordHash VARBINARY(MAX),
 @IdRol INT,
 @IdParticipante INT
)
AS
BEGIN
	INSERT INTO [dbo].[Usuario]
           ([UsuarioKey]
           ,[Username]
           ,[PasswordSalt]
           ,[PasswordHash]
           ,[FechaCreacion]
           ,[Activo]
           ,[IdRol]
           ,[IdParticipante])
     VALUES
           (@UsuarioKey, 
           @Username,
           @PasswordSalt, 
           @PasswordHash, 
           GETDATE(),
           1,
           @IdRol, 
           @IdParticipante);
	SELECT SCOPE_IDENTITY();
END;