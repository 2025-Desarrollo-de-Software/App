using Microsoft.Extensions.DependencyInjection;
using TripGo.CitySearch;
using TripGo.Ratings;
using Volo.Abp.Account;
using Volo.Abp.AutoMapper;
using Volo.Abp.Data;
using Volo.Abp.FeatureManagement;
using Volo.Abp.Identity;
using Volo.Abp.Modularity;
using Volo.Abp.PermissionManagement;
using Volo.Abp.SettingManagement;
using Volo.Abp.TenantManagement;

namespace TripGo;

[DependsOn(
    typeof(TripGoDomainModule),
    typeof(TripGoApplicationContractsModule),
    typeof(AbpPermissionManagementApplicationModule),
    typeof(AbpFeatureManagementApplicationModule),
    typeof(AbpIdentityApplicationModule),
    typeof(AbpAccountApplicationModule),
    typeof(AbpTenantManagementApplicationModule),
    typeof(AbpSettingManagementApplicationModule)
    )]
public class TripGoApplicationModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpAutoMapperOptions>(options =>
        {
            options.AddMaps<TripGoApplicationModule>();
        });

        //Cliente HTTP para servicio de busqueda de ciudades
        context.Services.AddHttpClient<ICitySearchService, GeoDbCitySearchService>();
        //Filtro automatico para IUserOwned
        Configure<AbpDataFilterOptions>(options =>
        {
            options.DefaultStates[typeof(IUserOwned)] = new DataFilterState(isEnabled: true);
        });
        context.Services.AddSingleton<IDataFilter<IUserOwned>, DataFilter<IUserOwned>>();

    }
}
