CREATE PROCEDURE [dbo].[UpdateLeccionMaterial]
	@IdLeccionMaterial int,
	@Titulo varchar(100),
	@ContenidoTexto text = NULL,
	@IdPublico varchar(100) = NULL,
	@Url varchar(500)  = NULL
AS
BEGIN
UPDATE [dbo].[LeccionMaterial]
SET [Titulo] = @Titulo,
    [ContenidoTexto] = @ContenidoTexto,
    [IdPublico] = @IdPublico,
	[Url] = @Url
WHERE [IdLeccionMaterial] = @IdLeccionMaterial;
SELECT @@ROWCOUNT;
END
