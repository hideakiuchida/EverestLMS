CREATE PROCEDURE [dbo].[GetEtapasByParticipante]
	@IdParticipante VARCHAR(1000)
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
  INNER JOIN Usuario u ON u.IdParticipante = p.IdParticipante
  WHERE u.UsuarioKey = @IdParticipante;
END
