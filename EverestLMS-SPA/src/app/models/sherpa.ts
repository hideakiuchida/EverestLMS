import { Conocimiento } from './conocimiento';
import { Escalador } from './escalador';

export interface Sherpa {
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
    conocimientosString: string;
    añosExperiencia: number;
    calificacion: number;
    escaladores: Escalador[];
}
