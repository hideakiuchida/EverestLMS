CREATE PROCEDURE [dbo].[GetExamen]
	@Id INT
AS
BEGIN
	SELECT [Id]
      ,[UsuarioKey]
      ,[IdCurso]
      ,[IdLeccion]
      ,[Nota]
      ,[VidasRestante]
      ,[TiempoRestante]
      ,[FechaFinalizado]
  FROM [dbo].[Examen]
  WHERE [Id] = @Id;
END
