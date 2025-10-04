using System;
using System.Linq;
using System.Threading.Tasks;
using Shouldly;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Modularity;
using Volo.Abp.Validation;
using Xunit;


namespace TripGo.Destinations
{
    public abstract class DestinationAppService_Tests<TStartupModule> : TripGoApplicationTestBase<TStartupModule>
        where TStartupModule : IAbpModule
    {
        private readonly IDestinationAppService _destinationAppService;

        protected DestinationAppService_Tests()
        {
            _destinationAppService = GetRequiredService<IDestinationAppService>();
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
            result.Items.ShouldNotBeEmpty();
            result.Items.ShouldNotBeNull();
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
            var result = await _destinationAppService.CreateAsync(createUpdateDestinationDto);
            //Assert

            result.Id.ShouldNotBe(Guid.Empty);
            result.Nombre.ShouldBe(createUpdateDestinationDto.Nombre);
            result.Pais.ShouldBe(createUpdateDestinationDto.Pais);
            result.Foto.ShouldBe(createUpdateDestinationDto.Foto);
            result.Poblacion.ShouldBe(createUpdateDestinationDto.Poblacion);
            result.Coordenadas.ShouldBe(createUpdateDestinationDto.Coordenadas);
            result.CantidadBusquedas.ShouldBe(createUpdateDestinationDto.CantidadBusquedas);
        }
        [Fact]
        public async Task Should_Not_Create_A_Destination_Without_Nombre()
        {
            //Arrange
            var createUpdateDestinationDto = new CreateUpdateDestinationDto
            {
                // Nombre is missing
                Pais = "Pais Prueba",
                Foto = "http://example.com/photo.jpg",
                Poblacion = 100000,
                Coordenadas = "40.7128,-74.0060",
                CantidadBusquedas = 0
            };
            //Act & Assert
            await Assert.ThrowsAsync<AbpValidationException>(async () =>
            {
                await _destinationAppService.CreateAsync(createUpdateDestinationDto);
            });
        }
    }
}
