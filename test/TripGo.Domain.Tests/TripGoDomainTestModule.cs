using Volo.Abp.Modularity;

namespace TripGo;

[DependsOn(
    typeof(TripGoDomainModule),
    typeof(TripGoTestBaseModule)
)]
public class TripGoDomainTestModule : AbpModule
{

}
