CREATE PROCEDURE [dbo].[CreateLeccion]
	@Nombre varchar(200),
	@Descripcion varchar(max),
	@Puntaje int,
	@IdCurso int
AS
BEGIN

DECLARE @NuevoNumeroOrden INT;
DECLARE @ActualNumeroOrden INT;

SET @ActualNumeroOrden = (SELECT TOP 1 [NumeroOrden] FROM [dbo].[Leccion] WHERE IdCurso = @IdCurso ORDER BY [NumeroOrden] DESC);
SET @ActualNumeroOrden = ISNULL(@ActualNumeroOrden, 0);
SET @NuevoNumeroOrden = @ActualNumeroOrden + 1;

INSERT INTO [dbo].[Leccion]
           ([Nombre]
           ,[Descripcion]
           ,[Puntaje]
           ,[NumeroOrden]
           ,[FechaCreacion]
           ,[IdCurso])
     VALUES
           (@Nombre
           ,@Descripcion
           ,@Puntaje
           ,@NuevoNumeroOrden
		   , GETDATE()
           ,@IdCurso);
SELECT SCOPE_IDENTITY();
END
