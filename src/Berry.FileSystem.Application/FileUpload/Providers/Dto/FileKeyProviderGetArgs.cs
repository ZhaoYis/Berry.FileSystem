namespace Berry.FileSystem.FileUpload.Providers.Dto;

public class FileKeyProviderGetArgs
{
    public FileKeyProviderGetArgs()
    {
    }

    public FileKeyProviderGetArgs(string clientId, string fileName)
    {
        ClientId = clientId;
        FileName = fileName;
    }

    /// <summary>
    ///     客户端标识码。如果使用/分割，在文件系统模式下表示路径
    /// </summary>
    public string ClientId { get; set; }

    /// <summary>
    ///     文件名称
    /// </summary>
    public string FileName { get; set; }
}