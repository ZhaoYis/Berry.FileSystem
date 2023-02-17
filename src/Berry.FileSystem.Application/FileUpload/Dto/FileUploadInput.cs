using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Berry.FileSystem.Configuration;
using Berry.FileSystem.Enumeration;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace Berry.FileSystem.FileUpload.Dto;

public class FileUploadInput : IValidatableObject
{
    /// <summary>
    ///     文件容器类型
    /// </summary>
    public FileContainerType ContainerType { get; set; } = FileContainerType.Default;

    /// <summary>
    ///     文件
    /// </summary>
    [Required]
    public IFormFile FormFile { get; set; }

    /// <summary>
    ///     ClientId
    /// </summary>
    [Required]
    public string ClientId { get; set; }

    /// <summary>
    ///     自定义验证
    /// </summary>
    /// <returns></returns>
    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
        //默认以最后一个.后面的内容为文件类型
        var extension = FormFile.FileName.Split('.').Last().ToLower();

        var options = validationContext.GetRequiredService<IOptions<FileUploadOptions>>().Value;

        if (!options.Extensions.Contains(string.Format(".{0}", extension)))
        {
            yield return new ValidationResult("系统暂不支持当前文件类型");
        }
        else
        {
            //限制大小
            if (FormFile.Length > options.MaxFileSize)
            {
                yield return new ValidationResult($"文件大小超出服务器允许的{options.MaxFileSize / (1024 * 1024)}MB限制");
            }
        }
    }
}