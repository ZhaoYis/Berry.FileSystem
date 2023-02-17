using System.Threading.Tasks;
using Berry.FileSystem.FileUpload.Handlers.Dto;
using Volo.Abp.DependencyInjection;

namespace Berry.FileSystem.FileUpload.Handlers;

public interface IFileUploadHandler : ITransientDependency
{
    /// <summary>
    ///     处理文件
    /// </summary>
    /// <returns></returns>
    Task<UploadDto> HandleAsync(UploadInput input);
}