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
    p.Puntaje, p.Rol, p.Photo, p.IdSede, p.Activo, p.idSherpa, p.idLineaCarrera, p.idNivel
    FROM participante p 
    WHERE p.idSherpa IS NULL
	AND (@Rol IS NULL OR p.Rol = @Rol)
	AND (@IdSede IS NULL OR p.IdSede = @IdSede)
	AND (@IdLineaCarrera IS NULL OR p.idLineaCarrera = @IdLineaCarrera)
	AND (@Search IS NULL OR (p.Nombre + ' ' + p.Apellido) LIKE '%' + @Search + '%')
	AND p.Activo = 1;
END;
