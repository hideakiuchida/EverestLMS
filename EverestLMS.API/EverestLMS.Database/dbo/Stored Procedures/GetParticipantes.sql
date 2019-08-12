CREATE PROCEDURE [dbo].[GetParticipantes]
(
 @IdParticipante INT = NULL,
 @IdNivel INT = NULL, 
 @IdLineaCarrera INT = NULL,
 @Rol INT = NULL,
 @Search VARCHAR(500) = NULL,
 @Sede VARCHAR(100) = NULL
)
AS
BEGIN
SET NOCOUNT ON;
	SELECT p.IdParticipante, p.Nombre, p.Apellido, p.Correo, p.Genero, p.FechaNacimiento, p.AñosExperiencia, p.Calificacion,
    p.Puntaje, p.Rol, p.Photo, p.Sede, p.Activo, p.idSherpa, p.idLineaCarrera, p.idNivel
    FROM participante p 
    WHERE (@IdNivel IS NULL OR p.idNivel = @IdNivel)
    AND (@IdLineaCarrera IS NULL OR p.idLineaCarrera = @IdLineaCarrera)
	AND (@IdParticipante IS NULL OR p.IdParticipante = @IdParticipante)
	AND (@Rol IS NULL OR p.Rol = @Rol)
	AND (@Sede IS NULL OR p.Sede = @Sede)
	AND (@Search IS NULL OR (p.Nombre + ' ' + p.Apellido) LIKE '%' + @Search + '%')
	AND p.Activo = 1;
END;
