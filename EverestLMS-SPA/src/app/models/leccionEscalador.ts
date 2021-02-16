import { LeccionMaterial } from './leccionMaterial';

export interface LeccionEscalador {
    id: number;
    idEtapa: number;
    idCurso: number;
    idParticipante: string;
    cursoImagenUrl: string;
    cursoNombre: string;
    nombre: string;
    contenidoHTML: string;
}