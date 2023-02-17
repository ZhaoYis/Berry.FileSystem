using Volo.Abp.Settings;

namespace Berry.FileSystem.Settings;

public class FileSystemSettingDefinitionProvider : SettingDefinitionProvider
{
    public override void Define(ISettingDefinitionContext context)
    {
        //Define your own settings here. Example:
        //context.Add(new SettingDefinition(FileSystemSettings.MySetting1));
    }
}