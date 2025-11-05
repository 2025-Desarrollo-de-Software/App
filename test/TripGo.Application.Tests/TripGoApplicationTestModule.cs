using Volo.Abp.Modularity;

namespace TripGo;

[DependsOn(
    typeof(TripGoApplicationModule),
    typeof(TripGoDomainTestModule)
)]
public class TripGoApplicationTestModule : AbpModule
{

}
