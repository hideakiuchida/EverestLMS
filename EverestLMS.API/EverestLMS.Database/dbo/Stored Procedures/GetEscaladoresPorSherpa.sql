CREATE PROCEDURE [dbo].[GetEscaladoresPorSherpa]
(
 @IdSherpa VARCHAR(1000),
 @Rol INT
)
AS
BEGIN
    DECLARE @IdParticipante INT = (SELECT u.IdParticipante FROM Usuario u WHERE u.UsuarioKey = @IdSherpa);
	SELECT p.IdParticipante, p.Nombre, p.Apellido, p.Correo, p.Genero, p.FechaNacimiento, p.AñosExperiencia, p.Calificacion,
    p.Puntaje, u.IdRol, p.Photo, p.IdSede, p.Activo, p.idSherpa, p.idLineaCarrera, p.idNivel, u.UsuarioKey
    FROM participante p INNER JOIN Usuario u ON p.IdParticipante = u.IdParticipante 
    WHERE p.idSherpa = @IdParticipante
	AND u.IdRol = @Rol
	AND p.Activo = 1;
END;