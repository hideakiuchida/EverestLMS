CREATE PROCEDURE [dbo].[GetConocimientosPorParticipante]
	@IdParticipante INT
AS
BEGIN
	SELECT [C].[IdConocimiento]
      ,[C].[Descripcion]
    FROM [dbo].[Conocimiento] [C]
	INNER JOIN [dbo].[ConocimientoParticipante] [CP] ON [C].[IdConocimiento] = [CP].[IdConocimiento]
	WHERE [CP].[IdParticipante] = @IdParticipante;
END
