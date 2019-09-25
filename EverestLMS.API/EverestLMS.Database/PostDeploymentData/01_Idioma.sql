MERGE INTO [Idioma] AS Target
USING (
		VALUES (1,'Inglés'), (2,'Español')
	) AS Source (IdIdioma,Descripcion)
ON Target.[IdIdioma] = Source.IdIdioma
WHEN MATCHED THEN
 UPDATE SET Descripcion= Source.Descripcion
WHEN NOT MATCHED BY TARGET THEN
 INSERT (IdIdioma, Descripcion)
 VALUES (IdIdioma, Descripcion);
