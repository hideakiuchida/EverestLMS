CREATE PROCEDURE [dbo].[GetExamen]
	@Id INT
AS
BEGIN
	SELECT [Id]
      ,[UsuarioKey]
      ,[IdEtapa]
      ,[IdCurso]
      ,[IdLeccion]
      ,[Nota]
      ,[VidasRestante]
      ,[TiempoRestante]
      ,[NumeroPreguntaActual]
      ,[FechaFinalizado]
  FROM [dbo].[Examen]
  WHERE [Id] = @Id;
END
