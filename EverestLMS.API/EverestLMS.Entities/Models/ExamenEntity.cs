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
        private readonly int VIDAS_POR_LECCION = 3;
        private readonly int VIDAS_POR_CURSO = 5;
        private readonly int TIEMPO_RESTANTE_POR_LECCION = 10000;
        private readonly int TIEMPO_RESTANTE_POR_CURSO = 30000;

        private IList<RespuestaEscaladorEntity> escaladorRespuestas;
        private int tiempoRestante;
        private int vidasRestante;

        public ExamenEntity()
        {

        }

        public ExamenEntity(int? idLeccion)
        {
            EscaladorRespuestas = new List<RespuestaEscaladorEntity>();
            IdLeccion = idLeccion;            
            VidasRestante = default;
            TiempoRestante = default;
        }

        public int Id { get; set; }
        public string UsuarioKey { get; set; }
        public int IdCurso { get; set; }
        public decimal Nota { get; set; }
        public int VidasRestante 
        { 
            get 
            {
                return vidasRestante;
            } 
            set
            {
                if (IdLeccion.HasValue)
                    vidasRestante = value == 0 ? VIDAS_POR_LECCION : value;
                else
                    vidasRestante = value == 0 ? VIDAS_POR_CURSO : value;
            }
        }
        public int TiempoRestante 
        { 
            get 
            {
                return tiempoRestante;
            } 
            set 
            {
                if (IdLeccion.HasValue)
                    tiempoRestante = value == 0 ? TIEMPO_RESTANTE_POR_LECCION : value;
                else
                    tiempoRestante = value == 0 ? TIEMPO_RESTANTE_POR_CURSO : value;
            } 
        }
        public int? IdLeccion { get; set; }
        public DateTime? FechaFinalizado { get; set; }
        public IList<RespuestaEscaladorEntity> EscaladorRespuestas {
            get 
            {
                return escaladorRespuestas;
            }
            set 
            {
                escaladorRespuestas = value;
                if (escaladorRespuestas.Any())
                {
                    var correctas = EscaladorRespuestas.Where(x => x.MarcoCorrecto.HasValue && x.MarcoCorrecto.Value);
                    Nota = !correctas.Any() ? 0 : correctas.Count() / EscaladorRespuestas.Count;
                }

            }
        }

        #region Business Rules
        
        public bool GenerarDiversidadPreguntasExamenPorCurso(IList<PreguntaEntity> preguntas) 
        {
            if (preguntas.Count < MINIMO_PREGUNTAS_POR_EXAMEN_CURSO) return false;

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

        #endregion

    }
}
