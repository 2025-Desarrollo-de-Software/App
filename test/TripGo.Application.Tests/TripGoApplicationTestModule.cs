using Volo.Abp.Modularity;

namespace TripGo;

[DependsOn(
    typeof(TripGoApplicationModule),
    typeof(TripGoDomainTestModule),
    typeof(TripGoTestBaseModule)
)]
public class TripGoApplicationTestModule : AbpModule
{

}
