using System;
using System.Threading.Tasks;
using Acme.TripGo;
using TripGo.Destinations;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories;

namespace Acme.TripGo;

public class DestinationStoreDataSeederContributor
    : IDataSeedContributor, ITransientDependency
{
    private readonly IRepository<Destination, Guid> _destinationRepository;

    public DestinationStoreDataSeederContributor(IRepository<Destination, Guid> destinationRepository)
    {
        _destinationRepository = destinationRepository;
    }

    public async Task SeedAsync(DataSeedContext context)
    {
        if (await _destinationRepository.GetCountAsync() <= 0)
        {
            await _destinationRepository.InsertAsync(
                new Destination
                {
                    Nombre = "PruebaNombre",
                    Pais = "PruebaPais",
                    Foto = "http://example.com/photo.jpg",
                    Poblacion = 500000,
                    Coordenadas = "40.7128,-74.0060",
                    CantidadBusquedas = 0
                },
                autoSave: true
            );
        }
    }
}
