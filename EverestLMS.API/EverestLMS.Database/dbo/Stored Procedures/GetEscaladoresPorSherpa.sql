CREATE PROCEDURE [dbo].[GetEscaladoresPorSherpa]
(
 @IdSherpa INT,
 @Rol INT
)
AS
BEGIN
SET NOCOUNT ON;
	SELECT p.IdParticipante, p.Nombre, p.Apellido, p.Correo, p.Genero, p.FechaNacimiento, p.AñosExperiencia, p.Calificacion,
    p.Puntaje, p.Rol, p.Photo, p.Sede, p.Activo, p.idSherpa, p.idLineaCarrera, p.idNivel
    FROM participante p 
    WHERE p.idSherpa = @IdSherpa
	AND p.Rol = @Rol
	AND p.Activo = 1;
END;