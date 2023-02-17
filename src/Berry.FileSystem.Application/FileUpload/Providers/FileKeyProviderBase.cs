using System.Threading.Tasks;
using Berry.FileSystem.FileUpload.Providers.Dto;

namespace Berry.FileSystem.FileUpload.Providers;

public abstract class FileKeyProviderBase : IFileKeyProvider
{
    /// <summary>
    ///     计算文件标识码
    /// </summary>
    /// <param name="args"></param>
    /// <returns></returns>
    public abstract Task<FileKeyProviderDto> GetFileKeyAsync(FileKeyProviderGetArgs args);

    /// <summary>
    ///     根据文件标识码获取BLOB名称
    /// </summary>
    /// <param name="fileKey"></param>
    /// <returns></returns>
    public abstract Task<string> GetBlobNameFromFileKeyAsync(string fileKey);
}