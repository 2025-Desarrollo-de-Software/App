using TripGo.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.Modularity;

namespace TripGo.DbMigrator;

[DependsOn(
    typeof(AbpAutofacModule),
    typeof(TripGoEntityFrameworkCoreModule),
    typeof(TripGoApplicationContractsModule)
)]
public class TripGoDbMigratorModule : AbpModule
{
}
