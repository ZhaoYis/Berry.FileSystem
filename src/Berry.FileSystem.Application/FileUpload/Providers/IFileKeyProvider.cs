using System.Threading.Tasks;
using Berry.FileSystem.FileUpload.Providers.Dto;
using Volo.Abp.DependencyInjection;

namespace Berry.FileSystem.FileUpload.Providers;

public interface IFileKeyProvider : ITransientDependency
{
    /// <summary>
    ///     计算文件标识码
    /// </summary>
    /// <param name="args"></param>
    /// <returns></returns>
    Task<FileKeyProviderDto> GetFileKeyAsync(FileKeyProviderGetArgs args);

    /// <summary>
    ///     根据文件标识码获取BLOB名称
    /// </summary>
    /// <param name="fileKey"></param>
    /// <returns></returns>
    Task<string> GetBlobNameFromFileKeyAsync(string fileKey);
}