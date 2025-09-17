using Volo.Abp.Settings;

namespace TripGo.Settings;

public class TripGoSettingDefinitionProvider : SettingDefinitionProvider
{
    public override void Define(ISettingDefinitionContext context)
    {
        //Define your own settings here. Example:
        //context.Add(new SettingDefinition(TripGoSettings.MySetting1));
    }
}
