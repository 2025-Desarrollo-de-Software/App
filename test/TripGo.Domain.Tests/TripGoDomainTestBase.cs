using Volo.Abp.Modularity;

namespace TripGo;

/* Inherit from this class for your domain layer tests. */
public abstract class TripGoDomainTestBase<TStartupModule> : TripGoTestBase<TStartupModule>
    where TStartupModule : IAbpModule
{

}
