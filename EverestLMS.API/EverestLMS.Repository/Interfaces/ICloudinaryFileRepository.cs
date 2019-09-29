using EverestLMS.Entities.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EverestLMS.Repository.Interfaces
{
    public interface ICloudinaryFileRepository
    {
        Task<CloudinaryFileEntity> GetSpecificCloudinaryFilesAsync(int idCloudinaryFile, int? idReferencia);
        Task<IEnumerable<CloudinaryFileEntity>> GetCloudinaryFilesAsync(int? idReferencia);
        Task<int> CreateCloudinaryFileAsync(CloudinaryFileEntity cloudinaryFileEntity);
        Task<bool> EditCloudinaryFileAsync(CloudinaryFileEntity cloudinaryFileEntity);
        Task<bool> DeleteCloudinaryFileAsync(int idCloudinaryFile, int? idReferencia);
    }
}
