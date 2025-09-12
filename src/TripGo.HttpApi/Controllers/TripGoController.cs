using TripGo.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace TripGo.Controllers;

/* Inherit your controllers from this class.
 */
public abstract class TripGoController : AbpControllerBase
{
    protected TripGoController()
    {
        LocalizationResource = typeof(TripGoResource);
    }
}
