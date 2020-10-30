using System;
using System.Collections.Generic;
using System.Linq;

namespace EverestLMS.Entities.Models
{
    public class ExamenEntity
    {
        private readonly int MAXIMO_PREGUNTAS_POR_LECCION = 3;
        private readonly int MINIMO_PREGUNTAS_POR_EXAMEN_LECCION = 10;
        private readonly int MINIMO_PREGUNTAS_POR_EXAMEN_CURSO = 30;
        private readonly int VIDAS_POR_LECCION = 3; // NO SE UTILIZARA GAMIFICACION PARA EL EXAMEN PARA CURSO
        private readonly int TIEMPO_10_MINUTOS_EN_MILISEGUNDOS_POR_LECCION = 600000; 
        private readonly int TIEMPO_30_MINUTOS_EN_MILISEGUNDOS_POR_CURSO = 1800000;

        public ExamenEntity() 
        {
        }

        public ExamenEntity(int? idLeccion)
        {
            IdLeccion = idLeccion;
            if (idLeccion.HasValue)
            {
                TiempoRestante = TIEMPO_10_MINUTOS_EN_MILISEGUNDOS_POR_LECCION;
                VidasRestante = VIDAS_POR_LECCION;
            }
            else
            {
                TiempoRestante = TIEMPO_30_MINUTOS_EN_MILISEGUNDOS_POR_CURSO;
            }
        }

        public int Id { get; set; }
        public string UsuarioKey { get; set; }
        public int IdEtapa { get; set; }
        public int IdCurso { get; set; }
        public decimal Nota { get; set; }
        public int VidasRestante { get; set; }
        public int TiempoRestante { get; set; }
        public int? IdLeccion { get; set; }

        public int TotalPreguntas 
        { 
            get 
            {
                if (IdLeccion.HasValue)
                    return MINIMO_PREGUNTAS_POR_EXAMEN_LECCION;
                else
                    return MINIMO_PREGUNTAS_POR_EXAMEN_CURSO; 
            } 
        }
        public DateTime? FechaFinalizado { get; set; }
        public IList<RespuestaEscaladorEntity> EscaladorRespuestas { get; set; }
        public int NumeroPreguntaActual { get; set; }

        #region Business Rules

        public bool GenerarDiversidadPreguntasExamenPorCurso(IList<PreguntaEntity> preguntas) 
        {
            if (preguntas.Count < MINIMO_PREGUNTAS_POR_EXAMEN_CURSO) return false;

            EscaladorRespuestas = new List<RespuestaEscaladorEntity>();

            foreach (var pregunta in preguntas)
            {
                if (EscaladorRespuestas.Count == MINIMO_PREGUNTAS_POR_EXAMEN_CURSO)
                    break;
                var preguntasPorLeccion = EscaladorRespuestas.Where(x => x.IdLeccion == pregunta.IdLeccion);
                if (preguntasPorLeccion.Count() > MAXIMO_PREGUNTAS_POR_LECCION)
                    continue;
                var respuesta = new RespuestaEscaladorEntity
                {
                    IdPregunta = pregunta.IdPregunta,
                    DescripcionPregunta = pregunta.Descripcion,
                    IdLeccion = pregunta.IdLeccion
                };
                EscaladorRespuestas.Add(respuesta);
            }

            if (EscaladorRespuestas.Count < MINIMO_PREGUNTAS_POR_EXAMEN_CURSO)
                return false;

            return true;
        }

        public bool GenerarPreguntasExamenPorLeccion(IList<PreguntaEntity> preguntas)
        {
            if (preguntas.Count < MINIMO_PREGUNTAS_POR_EXAMEN_LECCION) return false;

            EscaladorRespuestas = new List<RespuestaEscaladorEntity>();

            foreach (var pregunta in preguntas)
            {
                if (EscaladorRespuestas.Count == MINIMO_PREGUNTAS_POR_EXAMEN_LECCION)
                    break;
                var respuesta = new RespuestaEscaladorEntity
                {
                    IdPregunta = pregunta.IdPregunta,
                    DescripcionPregunta = pregunta.Descripcion,
                    IdLeccion = pregunta.IdLeccion
                };
                EscaladorRespuestas.Add(respuesta);
            }

            return true;
        }

        public void CalcularNota() 
        {
            if (EscaladorRespuestas.Any())
            {
                var correctas = EscaladorRespuestas.Where(x => x.MarcoCorrecto.HasValue && x.MarcoCorrecto.Value).ToList();
                Nota = !correctas.Any() ? 0 : Decimal.Divide(correctas.Count, EscaladorRespuestas.Count) * 100;
            }
        }

        #endregion

    }
}
