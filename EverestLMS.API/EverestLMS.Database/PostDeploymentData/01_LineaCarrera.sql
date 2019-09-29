MERGE INTO lineacarrera AS Target
USING (
		VALUES (1,'Business Analyist'), (2,'Software Engineer'), (3,'DevOps Engineer'), (4,'Mobile Engineer'), (5,'Quality Assurance')
	) AS Source (IdLineaCarrera,Descripcion)
ON Target.[IdLineaCarrera] = Source.IdLineaCarrera
WHEN MATCHED THEN
 UPDATE SET Descripcion= Source.Descripcion
WHEN NOT MATCHED BY TARGET THEN
 INSERT (IdLineaCarrera, Descripcion)
 VALUES (IdLineaCarrera, Descripcion);
