using System.Threading.Tasks;
using Berry.FileSystem.FileDownload.Handlers.Dto;
using Volo.Abp.DependencyInjection;

namespace Berry.FileSystem.FileDownload.Handlers;

public interface IFileDownloadHandler : ITransientDependency
{
    /// <summary>
    ///     处理文件
    /// </summary>
    /// <returns></returns>
    Task<DownloadDto> HandleAsync(DownloadInput input);
}