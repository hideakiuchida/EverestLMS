using EverestLMS.Entities.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EverestLMS.Repository.Interfaces
{
    public interface ILeccionRepository
    {
        Task<IEnumerable<LeccionDetalleEntity>> GetLeccionesDetalleAsync(int? idNivel, int? idLineaCarrera, int? idEtapa, int? idCurso, string search);
        Task<LeccionEntity> GetSpecificLeccionAsync(int idEtapa, int idCurso, int idLeccion);
        Task<int> CreateLeccionAsync(LeccionEntity leccionEntity);
        Task<bool> EditLeccionAsync(LeccionEntity leccionEntity);
        Task<bool> DeleteLeccionAsync(int idEtapa, int idCurso, int idLeccion);
        Task<IEnumerable<LeccionMaterialEntity>> GetLeccionMaterialesAsync(int idLeccion);
        Task<LeccionMaterialEntity> GetSpecificLeccionMaterialAsync(int idLeccion, int idLeccionMaterial);
        Task<int> CreateLeccionMaterialAsync(LeccionMaterialEntity leccionMaterialEntity);
        Task<bool> DeleteLeccionMaterialAsync(int idLeccion, int idLeccionMaterial);

    }
}
