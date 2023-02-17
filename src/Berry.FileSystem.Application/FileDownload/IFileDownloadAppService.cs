using System.Threading.Tasks;
using Berry.FileSystem.FileDownload.Dto;
using Volo.Abp.Application.Services;

namespace Berry.FileSystem.FileDownload;

public interface IFileDownloadAppService : IApplicationService
{
    /// <summary>
    ///     文件下载
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    Task<FileDownloadDto> DownloadAsync(FileDownloadInput input);
}