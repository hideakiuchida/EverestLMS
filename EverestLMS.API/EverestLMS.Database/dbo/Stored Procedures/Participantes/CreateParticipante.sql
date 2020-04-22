CREATE PROCEDURE [dbo].[CreateParticipante] 
(
 @Nombre VARCHAR(100),
 @Apellido VARCHAR(100),
 @Correo VARCHAR(100),
 @Genero VARCHAR(45),
 @FechaNacimiento DATETIME,
 @AñosExperiencia INT,
 @Calificacion DECIMAL(4,2),
 @Puntaje INT,
 @Photo VARCHAR(500),
 @IdSede INT,
 @IdSherpa INT,
 @IdLineaCarrera INT,
 @IdNivel INT
)
AS
BEGIN
SET NOCOUNT ON;
	INSERT INTO participante
(Nombre,
Apellido,
Correo,
Genero,
FechaNacimiento,
AñosExperiencia,
Calificacion,
Puntaje,
Photo,
IdSede,
Activo,
idSherpa,
idLineaCarrera,
idNivel)
VALUES
(@Nombre,
@Apellido,
@Correo,
@Genero,
@FechaNacimiento,
@AñosExperiencia,
@Calificacion,
@Puntaje,
@Photo,
@IdSede,
1,
@IdSherpa,
@IdLineaCarrera,
@IdNivel);

SELECT SCOPE_IDENTITY();
END;
