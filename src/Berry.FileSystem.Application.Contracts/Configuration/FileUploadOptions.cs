using System.Collections.Generic;

namespace Berry.FileSystem.Configuration;

public class FileUploadOptions
{
    /// <summary>
    ///     文件上传支持的扩展名称集合。默认仅支持zip格式文件
    /// </summary>
    public IList<string> Extensions { get; set; } = new List<string> { "zip" };

    /// <summary>
    ///     最大允许上传文件大小。默认20MB
    /// </summary>
    public int MaxFileSize { get; set; } = 20 * 1024 * 1024;

    /// <summary>
    ///     设置为 true,如果BLOB内容已经存在,则替换它. 默认值为 false,则抛出 BlobAlreadyExistsException 异常
    /// </summary>
    public bool OverrideExisting { get; set; } = false;

    /// <summary>
    ///     如果BLOB内容已经存在，是否重命名文件名称
    /// </summary>
    public bool ResettingFileNameIfExisting { get; set; } = false;
}