export interface Leccion {
    id?: number;
    nombre: string;
    descripcion: string;
    idDificultad: number;
    puntaje: number;
    numeroOrden: number;
    fechaCreacion: Date;
    idCurso: number;
    idEtapa: number;
    cursoDescripcion: string;
    idiomaDescripcion: string;
    etapaDescripcion: string;
    nombreEtapa: string;
    nivelDescripcion: string;
    lineaCarreraDescripcion: string;
    dificultadDescripcion: string;
    autor: string;
}
