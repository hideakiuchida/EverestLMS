import { Respuesta } from './respuesta';

export class PreguntaExamen {
    idRespuestaEscalador: number;
    idPregunta: number;
    descripcionPregunta: string;
    imagen: string;
    numeroOrden: number;
    respuestas: Respuesta[];
}
