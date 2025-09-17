using TripGo.Localization;
using Volo.Abp.Application.Services;

namespace TripGo;

/* Inherit your application services from this class.
 */
public abstract class TripGoAppService : ApplicationService
{
    protected TripGoAppService()
    {
        LocalizationResource = typeof(TripGoResource);
    }
}
