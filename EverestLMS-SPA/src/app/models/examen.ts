export class Examen {
    id: number;
    idEtapa: number;
    idCurso: number;
    idLeccion?: number;
    nota: number;
    vidasRestante: number;
    tiempoRestante: number;
    fechaFinalizado: Date;
    numeroPreguntaActual: number;
    totalPreguntas: number;
}
