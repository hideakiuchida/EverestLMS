CREATE PROCEDURE [dbo].[GetConocimientosPorParticipante]
	@IdParticipante VARCHAR(1000)
AS
BEGIN
	DECLARE @IdParti INT = (SELECT u.IdParticipante FROM Usuario u WHERE u.UsuarioKey = @IdParticipante);
	SELECT [C].[IdConocimiento]
      ,[C].[Descripcion]
    FROM [dbo].[Conocimiento] [C]
	INNER JOIN [dbo].[ConocimientoParticipante] [CP] ON [C].[IdConocimiento] = [CP].[IdConocimiento]
	WHERE [CP].[IdParticipante] = @IdParti;
END
