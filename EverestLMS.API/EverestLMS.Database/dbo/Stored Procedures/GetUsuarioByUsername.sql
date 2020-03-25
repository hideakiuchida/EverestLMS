CREATE PROCEDURE [dbo].[GetUsuarioByUsername]
	@Username VARCHAR(50)
AS
  SELECT [UsuarioKey]
       ,[Username]
      ,[PasswordSalt]
      ,[PasswordHash]
      , [IdRol]
  FROM [EVERESTLMS].[dbo].[Usuario]
  WHERE [Username] = @Username;
