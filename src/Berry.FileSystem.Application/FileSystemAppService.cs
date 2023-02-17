using Berry.FileSystem.Localization;
using Volo.Abp.Application.Services;

namespace Berry.FileSystem;

/* Inherit your application services from this class.
 */
public abstract class FileSystemAppService : ApplicationService
{
    protected FileSystemAppService()
    {
        LocalizationResource = typeof(FileSystemResource);
    }
}