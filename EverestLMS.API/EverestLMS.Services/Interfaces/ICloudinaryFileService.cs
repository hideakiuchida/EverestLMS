using EverestLMS.ViewModels.CloudinaryFile;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EverestLMS.Services.Interfaces
{
    public interface ICloudinaryFileService
    {
        Task<CloudinaryFileVM> GetSpecificCloudinaryFilesAsync(int idCloudinaryFile, int? idCurso = null, int? idLeccion = null, int? idPregunta = null, int? idRespuesta = null, int? idUsuario = null);
        Task<IEnumerable<CloudinaryFileVM>> GetCloudinaryFilesAsync(int? idCurso = null, int? idLeccion = null, int? idPregunta = null, int? idRespuesta = null, int? idUsuario = null);
        Task<int> CreateCloudinaryFileAsync(CloudinaryFileToCreateVM cloudinaryFileEntity);
        Task<bool> EditCloudinaryFileAsync(CloudinaryFileToUpdateVM cloudinaryFileEntity);
        Task<bool> DeleteCloudinaryFileAsync(int idCloudinaryFile, int? idCurso = null, int? idLeccion = null, int? idPregunta = null, int? idRespuesta = null, int? idUsuario = null);
    }
}
