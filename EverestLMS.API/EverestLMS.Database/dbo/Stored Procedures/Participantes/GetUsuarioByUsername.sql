CREATE PROCEDURE [dbo].[GetUsuarioByUsername]
	@Username VARCHAR(50)
AS
  SELECT [u].[UsuarioKey]
       ,[u].[Username]
      ,[u].[PasswordSalt]
      ,[u].[PasswordHash]
      , [u].[IdRol]
      , [p].[Puntaje]
  FROM [dbo].[Usuario] [u]
  INNER JOIN [dbo].[Participante] [p] ON [u].[IdParticipante] = [p].[IdParticipante] 
  WHERE [Username] = @Username;
