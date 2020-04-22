CREATE PROCEDURE [dbo].[DeleteLeccionMaterial]
	@IdLeccionMaterial int,
	@IdLeccion int
AS
BEGIN
 DELETE FROM [dbo].[LeccionMaterial]
 WHERE IdLeccion = @IdLeccion
 AND IdLeccionMaterial = @IdLeccionMaterial;
 SELECT @@ROWCOUNT;
END
