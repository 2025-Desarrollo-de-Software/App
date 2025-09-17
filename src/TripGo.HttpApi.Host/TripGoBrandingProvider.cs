using Microsoft.Extensions.Localization;
using TripGo.Localization;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Ui.Branding;

namespace TripGo;

[Dependency(ReplaceServices = true)]
public class TripGoBrandingProvider : DefaultBrandingProvider
{
    private IStringLocalizer<TripGoResource> _localizer;

    public TripGoBrandingProvider(IStringLocalizer<TripGoResource> localizer)
    {
        _localizer = localizer;
    }

    public override string AppName => _localizer["AppName"];
}
