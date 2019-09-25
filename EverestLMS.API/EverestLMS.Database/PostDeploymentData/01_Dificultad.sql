MERGE INTO [Dificultad] AS Target
USING (
		VALUES (1,'Fácil'), (2,'Medio'), (3,'Dificil')
	) AS Source (IdDificultad,Descripcion)
ON Target.[IdDificultad] = Source.IdDificultad
WHEN MATCHED THEN
 UPDATE SET Descripcion= Source.Descripcion
WHEN NOT MATCHED BY TARGET THEN
 INSERT (IdDificultad, Descripcion)
 VALUES (IdDificultad, Descripcion);
