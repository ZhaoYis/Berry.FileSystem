using Microsoft.AspNetCore.Http;

namespace Berry.FileSystem.FileUpload.Handlers.Dto;

public class UploadInput
{
    /// <summary>
    ///     文件
    /// </summary>
    public IFormFile FormFile { get; set; }

    /// <summary>
    ///     ClientId
    /// </summary>
    public string ClientId { get; set; }
}