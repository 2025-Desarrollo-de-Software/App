using Volo.Abp.Modularity;

namespace TripGo;

public abstract class TripGoApplicationTestBase<TStartupModule> : TripGoTestBase<TStartupModule>
    where TStartupModule : IAbpModule
{

}
