CREATE PROCEDURE [dbo].[UpdateExamen]
(
 @IdExamen INT,
 @Nota decimal(4,2) NULL,
 @VidasRestante INT NULL, 
 @TiempoRestante INT NULL,
 @FechaFinalizado DATETIME NULL
)
AS
BEGIN
SET NOCOUNT ON;
 UPDATE [dbo].[Examen]
 SET [Nota] = CASE WHEN @Nota IS NULL THEN [Nota] ELSE @Nota END
      ,[VidasRestante] = CASE WHEN @VidasRestante IS NULL THEN [VidasRestante] ELSE @VidasRestante END
      ,[TiempoRestante] = CASE WHEN @TiempoRestante IS NULL THEN [TiempoRestante] ELSE @TiempoRestante END
      ,[FechaFinalizado] = CASE WHEN @FechaFinalizado IS NULL THEN [FechaFinalizado] ELSE @FechaFinalizado END
 WHERE [Id] = @IdExamen;
 SELECT @@ROWCOUNT;
END;
