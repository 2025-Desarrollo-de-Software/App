using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace TripGo.Data;

/* This is used if database provider does't define
 * ITripGoDbSchemaMigrator implementation.
 */
public class NullTripGoDbSchemaMigrator : ITripGoDbSchemaMigrator, ITransientDependency
{
    public Task MigrateAsync()
    {
        return Task.CompletedTask;
    }
}
