using Berry.FileSystem.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace Berry.FileSystem.Controllers;

public abstract class ControllerBase : AbpController
{
    protected ControllerBase()
    {
        LocalizationResource = typeof(FileSystemResource);
    }
}