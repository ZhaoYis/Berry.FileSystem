namespace Berry.FileSystem.FileUpload.Handlers.Dto;

public class UploadDto
{
    /// <summary>
    ///     文件标识码
    /// </summary>
    public string FileKey { get; set; }

    /// <summary>
    ///     文件所在路径。仅文件系统下支持
    /// </summary>
    public string FilePath { get; set; }
}