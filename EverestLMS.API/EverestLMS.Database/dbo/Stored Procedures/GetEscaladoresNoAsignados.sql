CREATE PROCEDURE [dbo].[GetEscaladoresNoAsignados]
(
 @IdLineaCarrera INT NULL,
 @Rol INT = NULL,
 @Search VARCHAR(500) = NULL,
 @IdSede INT = NULL
)
AS
BEGIN
SET NOCOUNT ON;
	SELECT p.IdParticipante, p.Nombre, p.Apellido, p.Correo, p.Genero, p.FechaNacimiento, p.AñosExperiencia, p.Calificacion,
    p.Puntaje, u.IdRol as Rol, p.Photo, p.IdSede, p.Activo, p.idSherpa, p.idLineaCarrera, p.idNivel, u.UsuarioKey
    FROM participante p INNER JOIN Usuario u ON p.IdParticipante = u.IdParticipante 
    WHERE p.idSherpa IS NULL
	AND (@Rol IS NULL OR u.IdRol = @Rol)
	AND (@IdSede IS NULL OR p.IdSede = @IdSede)
	AND (@IdLineaCarrera IS NULL OR p.idLineaCarrera = @IdLineaCarrera)
	AND (@Search IS NULL OR (p.Nombre + ' ' + p.Apellido) LIKE '%' + @Search + '%')
	AND p.Activo = 1;
END;
