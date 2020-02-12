DELETE FROM evento;

INSERT INTO evento (Titulo, Descripcion, FechaInicio, FechaFinal, ColorPrimario, ColorSecundario, IdCalendario) 
VALUES ('Calendario Everest 2018-01', 'Calendario Everest 2018-01', '2018-01-01 00:00:00', '2018-04-30 00:00:00', '#ad2121', '#FAE3E3',
(SELECT TOP 1 IdCalendario FROM calendario WHERE Descripcion = 'Calendario Everest 2018-01'));
INSERT INTO evento (Titulo, Descripcion, FechaInicio, FechaFinal, ColorPrimario, ColorSecundario, IdCalendario) 
VALUES ('Calendario Everest 2018-02', 'Calendario Everest 2018-01', '2018-05-01 00:00:00', '2018-08-31 00:00:00', '#1e90ff', '#D1E8FF',
(SELECT TOP 1 IdCalendario FROM calendario WHERE Descripcion = 'Calendario Everest 2018-02'));
INSERT INTO evento (Titulo, Descripcion, FechaInicio, FechaFinal, ColorPrimario, ColorSecundario, IdCalendario) 
VALUES ('Calendario Everest 2018-03', 'Calendario Everest 2018-01', '2018-09-01 00:00:00', '2018-12-31 00:00:00', '#e3bc08', '#FDF1BA',
(SELECT TOP 1 IdCalendario FROM calendario WHERE Descripcion = 'Calendario Everest 2018-03'));
INSERT INTO evento (Titulo, Descripcion, FechaInicio, FechaFinal, ColorPrimario, ColorSecundario, IdCalendario) 
VALUES ('Calendario Everest 2019-01', 'Calendario Everest 2019-01', '2019-01-01 00:00:00', '2019-04-30 00:00:00', '#ad2121', '#FAE3E3',
(SELECT TOP 1 IdCalendario FROM calendario WHERE Descripcion = 'Calendario Everest 2019-01'));
INSERT INTO evento (Titulo, Descripcion, FechaInicio, FechaFinal, ColorPrimario, ColorSecundario, IdCalendario) 
VALUES ('Calendario Everest 2019-02', 'Calendario Everest 2019-01', '2019-05-01 00:00:00', '2019-08-31 00:00:00', '#1e90ff', '#D1E8FF',
(SELECT TOP 1 IdCalendario FROM calendario WHERE Descripcion = 'Calendario Everest 2019-02'));
INSERT INTO evento (Titulo, Descripcion, FechaInicio, FechaFinal, ColorPrimario, ColorSecundario, IdCalendario) 
VALUES ('Calendario Everest 2019-03', 'Calendario Everest 2019-01', '2019-09-01 00:00:00', '2019-12-31 00:00:00', '#e3bc08', '#FDF1BA',
(SELECT TOP 1 IdCalendario FROM calendario WHERE Descripcion = 'Calendario Everest 2019-03'));
INSERT INTO evento (Titulo, Descripcion, FechaInicio, FechaFinal, ColorPrimario, ColorSecundario, IdCalendario) 
VALUES ('Calendario Everest 2020-01', 'Calendario Everest 2020-01', '2020-01-01 00:00:00', '2020-04-30 00:00:00', '#ad2121', '#FAE3E3',
(SELECT TOP 1 IdCalendario FROM calendario WHERE Descripcion = 'Calendario Everest 2020-01'));
INSERT INTO evento (Titulo, Descripcion, FechaInicio, FechaFinal, ColorPrimario, ColorSecundario, IdCalendario) 
VALUES ('Calendario Everest 2020-02', 'Calendario Everest 2020-01', '2020-05-01 00:00:00', '2020-08-31 00:00:00', '#1e90ff', '#D1E8FF',
(SELECT TOP 1 IdCalendario FROM calendario WHERE Descripcion = 'Calendario Everest 2020-02'));
INSERT INTO evento (Titulo, Descripcion, FechaInicio, FechaFinal, ColorPrimario, ColorSecundario, IdCalendario) 
VALUES ('Calendario Everest 2020-03', 'Calendario Everest 2020-01', '2020-09-01 00:00:00', '2020-12-31 00:00:00', '#e3bc08', '#FDF1BA',
(SELECT TOP 1 IdCalendario FROM calendario WHERE Descripcion = 'Calendario Everest 2020-03'));