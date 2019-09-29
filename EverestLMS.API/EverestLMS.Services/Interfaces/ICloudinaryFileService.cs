using EverestLMS.ViewModels.CloudinaryFile;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EverestLMS.Services.Interfaces
{
    public interface ICloudinaryFileService
    {
        Task<CloudinaryFileVM> GetSpecificCloudinaryFilesAsync(int idCloudinaryFile, int? idReferencia);
        Task<IEnumerable<CloudinaryFileVM>> GetCloudinaryFilesAsync(int? idReferencia);
        Task<int> CreateCloudinaryFileAsync(CloudinaryFileToCreateVM cloudinaryFileEntity);
        Task<bool> EditCloudinaryFileAsync(CloudinaryFileToUpdateVM cloudinaryFileEntity);
        Task<bool> DeleteCloudinaryFileAsync(int idCloudinaryFile, int? idReferencia);
    }
}
