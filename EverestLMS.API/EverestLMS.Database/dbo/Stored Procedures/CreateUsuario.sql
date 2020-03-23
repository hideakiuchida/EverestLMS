CREATE PROCEDURE [dbo].[CreateUsuario]
(
 @UsuarioKey VARCHAR(1000), 
 @PasswordSalt VARCHAR(1000),
 @PasswordHash VARCHAR(1000),
 @IdRol INT,
 @IdParticipante INT
)
AS
BEGIN
	INSERT INTO [dbo].[Usuario]
           ([UsuarioKey]
           ,[PasswordSalt]
           ,[PasswordHash]
           ,[FechaCreacion]
           ,[Activo]
           ,[IdRol]
           ,[IdParticipante])
     VALUES
           (@UsuarioKey, 
           @PasswordSalt, 
           @PasswordHash, 
           GETDATE(),
           1,
           @IdRol, 
           @IdParticipante);
	SELECT SCOPE_IDENTITY();
END;