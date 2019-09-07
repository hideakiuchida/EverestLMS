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

:r .\01_Conocimiento.sql
:r .\01_LineaCarrera.sql
:r .\01_Nivel.sql
:r .\01_Sede.sql
:r .\02_Etapa.sql
:r .\03_Curso.sql
