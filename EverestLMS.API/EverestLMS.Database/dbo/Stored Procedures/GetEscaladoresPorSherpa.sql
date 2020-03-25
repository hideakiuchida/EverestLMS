CREATE PROCEDURE [dbo].[GetEscaladoresPorSherpa]
(
 @IdSherpa INT,
 @Rol INT
)
AS
BEGIN
SET NOCOUNT ON;
	SELECT p.IdParticipante, p.Nombre, p.Apellido, p.Correo, p.Genero, p.FechaNacimiento, p.AñosExperiencia, p.Calificacion,
    p.Puntaje, u.IdRol, p.Photo, p.IdSede, p.Activo, p.idSherpa, p.idLineaCarrera, p.idNivel
    FROM participante p INNER JOIN Usuario u ON p.IdParticipante = u.IdParticipante 
    WHERE p.idSherpa = @IdSherpa
	AND u.IdRol = @Rol
	AND p.Activo = 1;
END;