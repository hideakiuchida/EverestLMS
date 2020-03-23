CREATE PROCEDURE [dbo].[GetUsuarioByUsername]
	@Username VARCHAR(50)
AS
  SELECT [UsuarioKey]
      ,[PasswordSalt]
      ,[PasswordHash]
  FROM [EVERESTLMS].[dbo].[Usuario]
  WHERE [Username] = @Username;
