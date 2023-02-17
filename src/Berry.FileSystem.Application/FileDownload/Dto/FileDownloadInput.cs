using Berry.FileSystem.Enumeration;

namespace Berry.FileSystem.FileDownload.Dto;

public class FileDownloadInput
{
    /// <summary>
    ///     文件容器类型
    /// </summary>
    public FileContainerType ContainerType { get; set; } = FileContainerType.Default;

    /// <summary>
    ///     文件标识码
    /// </summary>
    public string FileKey { get; set; }
}