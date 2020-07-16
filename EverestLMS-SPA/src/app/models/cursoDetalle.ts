import { Curso } from './curso';
import { Leccion } from './leccion';

export interface CursoDetalle extends Curso  {
    lecciones: Leccion[];
}
