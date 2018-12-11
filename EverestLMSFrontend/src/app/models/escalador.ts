import { Conocimiento } from './conocimiento';

export interface Escalador {
    id: number;
    nombre: string;
    apellido: string;
    correo: string;
    genero: string;
    fechaNacimiento: Date;
    rol: number;
    idSherpa: number;
    nivel: string;
    idNivel: number;
    lineaCarrera: string;
    idLineaCarrera: number;
    photo: string;
    sede: string;
    conocimientos: Conocimiento[];
    puntaje: number;
}
