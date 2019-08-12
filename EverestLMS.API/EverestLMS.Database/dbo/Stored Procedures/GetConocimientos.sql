CREATE PROCEDURE [dbo].[GetConocimientos]
	@IdConocimiento INT = NULL
AS
BEGIN
	SELECT [IdConocimiento]
      ,[Descripcion]
    FROM [dbo].[Conocimiento]
	WHERE (@IdConocimiento IS NULL OR [IdConocimiento] = @IdConocimiento);
END
