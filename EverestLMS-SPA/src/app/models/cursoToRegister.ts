export interface CursoToRegister {
    id?: number;
    nombre: string;
    descripcion: string;
    idEtapa: number;
    puntaje: number;
    idDificultad: number;
    idIdioma: number;
    autor: string;
    imagen: string;
    idNivel?: number;
    idLineaCarrera?: number;
}
