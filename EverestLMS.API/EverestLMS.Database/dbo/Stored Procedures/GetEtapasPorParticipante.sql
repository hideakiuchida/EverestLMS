CREATE PROCEDURE [dbo].[GetEtapasByParticipante]
	@IdParticipante INT
AS
BEGIN
	SELECT e.[IdEtapa]
      ,e.[Nombre]
      ,e.[Descripcion]
      ,e.[NumeroOrden]
      ,e.[FechaCreacion]
      ,e.[IdNivel]
      ,e.[IdLineaCarrera]
  FROM [dbo].[Etapa] e
  INNER JOIN Participante p ON p.IdLineaCarrera = e.IdLineaCarrera AND p.IdNivel = e.IdNivel
  WHERE p.IdParticipante = @IdParticipante;
END
