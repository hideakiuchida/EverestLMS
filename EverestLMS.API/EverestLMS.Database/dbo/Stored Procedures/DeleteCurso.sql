﻿CREATE PROCEDURE [dbo].[DeleteCurso]
	@IdCurso int,
	@IdEtapa int
AS
BEGIN
	DELETE FROM [dbo].[Curso] WHERE IdCurso = @IdCurso AND IdEtapa = @IdEtapa;
	SELECT @@ROWCOUNT;
END