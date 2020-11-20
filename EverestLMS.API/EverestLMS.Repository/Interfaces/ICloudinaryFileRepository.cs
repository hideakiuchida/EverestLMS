using EverestLMS.Entities.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EverestLMS.Repository.Interfaces
{
    public interface ICloudinaryFileRepository
    {
        Task<CloudinaryFileEntity> GetSpecificCloudinaryFilesAsync(int idCloudinaryFile, int? idCurso = null, int? idLeccion = null, int? idPregunta = null, int? idRespuesta = null, int? idUsuario = null);
        Task<IEnumerable<CloudinaryFileEntity>> GetCloudinaryFilesAsync(int? idCurso = null, int? idLeccion = null, int? idPregunta = null, int? idRespuesta = null, int? idUsuario = null);
        Task<int> CreateCloudinaryFileAsync(CloudinaryFileEntity cloudinaryFileEntity);
        Task<bool> EditCloudinaryFileAsync(CloudinaryFileEntity cloudinaryFileEntity);
        Task<bool> DeleteCloudinaryFileAsync(int idCloudinaryFile, int? idCurso = null, int? idLeccion = null, int? idPregunta = null, int? idRespuesta = null, int? idUsuario = null);
    }
}
