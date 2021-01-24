/*
Post-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be appended to the build script.		
 Use SQLCMD syntax to include a file in the post-deployment script.			
 Example:      :r .\myfile.sql								
 Use SQLCMD syntax to reference a variable in the post-deployment script.		
 Example:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/
:r .\01_Rol.sql
:r .\01_Idioma.sql
:r .\01_Calendario.sql
:r .\01_Conocimiento.sql
:r .\01_LineaCarrera.sql
:r .\01_Nivel.sql
:r .\01_Sede.sql
:r .\01_Dificultad.sql
:r .\02_Etapa.sql
:r .\02_Evento.sql
:r .\03_Curso.sql
:r .\04_Leccion.sql
:r .\05_Pregunta.sql
:r .\06_Respuesta.sql
