CREATE PROCEDURE [dbo].[CreateLeccion]
	@Nombre varchar(200),
	@Descripcion varchar(max),
	@IdDificultad int,
	@Puntaje int,
	@NumeroOrden int,
	@IdCurso int
AS
BEGIN
INSERT INTO [dbo].[Leccion]
           ([Nombre]
           ,[Descripcion]
           ,[IdDificultad]
           ,[Puntaje]
           ,[NumeroOrden]
           ,[FechaCreacion]
           ,[IdCurso])
     VALUES
           (@Nombre
           ,@Descripcion
           ,@IdDificultad
           ,@Puntaje
           ,@NumeroOrden
		   , GETDATE()
           ,@IdCurso);
SELECT SCOPE_IDENTITY();
END
