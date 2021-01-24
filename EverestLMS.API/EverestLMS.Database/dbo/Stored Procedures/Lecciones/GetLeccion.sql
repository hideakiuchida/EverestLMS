CREATE PROCEDURE [dbo].[GetLeccion]
	@IdLeccion int,
	@IdCurso int,
	@IdEtapa int
AS
BEGIN
SELECT l.[IdLeccion]
      ,l.[Nombre]
      ,l.[Descripcion]
      ,l.[ContenidoHTML]
      ,l.[Puntaje]
      ,l.[NumeroOrden]
      ,l.[FechaCreacion]
      ,l.[IdCurso]
	  , c.IdEtapa
  FROM [dbo].[Leccion] l
  INNER JOIN [dbo].[Curso] c ON c.IdCurso = l.IdCurso
  WHERE l.IdLeccion = @IdLeccion 
  AND c.IdCurso = @IdCurso
  AND c.IdEtapa = @IdEtapa;
END
