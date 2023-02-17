using System.Threading.Tasks;
using Berry.FileSystem.FileUpload.Dto;
using Volo.Abp.Application.Services;

namespace Berry.FileSystem.FileUpload;

public interface IFileUploadAppService : IApplicationService
{
    /// <summary>
    ///     文件上传
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    Task<FileUploadDto> UploadAsync(FileUploadInput input);
}