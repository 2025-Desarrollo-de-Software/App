using Polly.Caching;
using Shouldly;
using System;
using System.Linq;
using System.Threading.Tasks;
using TripGo.EntityFrameworkCore;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.Modularity;
using Volo.Abp.Uow;
using Volo.Abp.Validation;
using Xunit;


namespace TripGo.Destinations
{
    public abstract class DestinationAppService_Tests<TStartupModule> : TripGoApplicationTestBase<TStartupModule>
        where TStartupModule : IAbpModule
    {
        private readonly IDestinationAppService _destinationAppService;
        private readonly IRepository<Destination, Guid> _destinationRepository;
        private readonly IUnitOfWorkManager _unitOfWorkManager;
        private readonly IDbContextProvider<TripGoDbContext> _dbContextProvider;

        protected DestinationAppService_Tests()
        {
            _destinationAppService = GetRequiredService<IDestinationAppService>();
            _destinationRepository = GetRequiredService<IRepository<Destination, Guid>>();
            _unitOfWorkManager = GetRequiredService<IUnitOfWorkManager>();
            _dbContextProvider = GetRequiredService<IDbContextProvider<TripGoDbContext>>();
        }

        [Fact]
        public async Task CreateAsync_ShouldPersistDestinationInDatabase()
        {
            using (var uow = _unitOfWorkManager.Begin())
            {
                // Arrange
                var input = new CreateUpdateDestinationDto
                {
                    Nombre = "Tokyo",
                    Pais = "Japan",
                    Poblacion = 13960000,
                    Foto = "https://example.com/tokyo.jpg",
                    Coordenadas = "35.6762,139.6503",
                    CantidadBusquedas = 0
                };

                // Act
                var result = await _destinationAppService.CreateAsync(input);

                // Assert - Verificar en la base de datos directamente
                var dbContext = await _dbContextProvider.GetDbContextAsync();
                var savedDestination = await dbContext.Destinations.FindAsync(result.Id);

                savedDestination.ShouldNotBeNull();
                savedDestination.Nombre.ShouldBe(input.Nombre);
                savedDestination.Pais.ShouldBe(input.Pais);
                savedDestination.Poblacion.ShouldBe(input.Poblacion);

                await uow.CompleteAsync();
            }
        }


        [Fact]
        public async Task Should_Get_List_Of_Destinations()
        {
            //Act
            var result = await _destinationAppService.GetListAsync(
                new PagedAndSortedResultRequestDto()
            );

            //Assert
            result.TotalCount.ShouldBeGreaterThan(0);
            result.Items.ShouldContain(d => d.Nombre == "PruebaNombre");

        }

        [Fact]
        public async Task Should_Create_A_Valid_Destination()
        {
            //Arrange
            var createUpdateDestinationDto = new CreateUpdateDestinationDto
            {
                Nombre = "Destino Prueba",
                Pais = "Pais Prueba",
                Foto = "http://example.com/photo.jpg",
                Poblacion = 100000,
                Coordenadas = "40.7128,-74.0060",
                CantidadBusquedas = 0
            };
            //Act
            var resultDto = await _destinationAppService.CreateAsync(createUpdateDestinationDto);
            //Assert - Parte 1: Verificar el DTO devuelto (esto ya lo tenías y está bien)
            resultDto.Id.ShouldNotBe(Guid.Empty);
            resultDto.Nombre.ShouldBe(createUpdateDestinationDto.Nombre);
        }
        [Fact]
        public async Task Should_Not_Create_A_Destination_Without_Nombre()
        {
            //Arrange
            var createUpdateDestinationDto = new CreateUpdateDestinationDto
            {
                Nombre = "",
                Pais = "Pais Prueba",
                Foto = "http://example.com/photo.jpg",
                Poblacion = 100000,
                Coordenadas = "40.7128,-74.0060",
                CantidadBusquedas = 0
            };
            //Act & Assert
            var exception = await Assert.ThrowsAsync<AbpValidationException>(async () =>
            {
                await _destinationAppService.CreateAsync(createUpdateDestinationDto);
            });

            exception.ValidationErrors
           .ShouldContain(err => err.MemberNames.Any(mem => mem == "Nombre"));
        }
    }
}
