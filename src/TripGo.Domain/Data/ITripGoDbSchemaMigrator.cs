using System.Threading.Tasks;

namespace TripGo.Data;

public interface ITripGoDbSchemaMigrator
{
    Task MigrateAsync();
}
