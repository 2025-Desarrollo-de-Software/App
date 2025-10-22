using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shouldly;
using TripGo.CitySearch;
using Xunit;

namespace TripGo.CitySearch
{
    // Etiqueta para ejecutar separadamente
    [Collection("IntegrationTests")]
    public class GeoDbCitySearchService_IntegrationTests : TripGoApplicationTestBase<TripGoApplicationModule>
    {
        private readonly ICitySearchService _citySearchService;

        public GeoDbCitySearchService_IntegrationTests()
        {
            _citySearchService = GetRequiredService<ICitySearchService>();
        }

        [Fact]
        public async Task SearchCitiesAsync_WithRealApi_ShouldReturnResults()
        {
            // Arrange
            var request = new CitySearchRequestDto
            {
                NamePrefix = "Buenos",
                Limit = 3
            };

            // Act
            var result = await _citySearchService.SearchCitiesAsync(request);

            // Assert
            result.ShouldNotBeNull();
            result.Cities.ShouldNotBeNull();
            result.Cities.Count.ShouldBeGreaterThan(0);
            result.Cities[0].Name.ShouldContain("Buenos");
        }

        [Fact]
        public async Task SearchCitiesAsync_WithNonExistentCity_ShouldReturnEmpty()
        {
            // Arrange
            var request = new CitySearchRequestDto
            {
                NamePrefix = "CiudadQueNoExiste12345",
                Limit = 5
            };

            // Act
            var result = await _citySearchService.SearchCitiesAsync(request);

            // Assert
            result.ShouldNotBeNull();
            result.Cities.ShouldBeEmpty();
        }

        [Fact]
        public async Task SearchCitiesAsync_WithSpecialCharacters_ShouldHandleCorrectly()
        {
            // Arrange
            var request = new CitySearchRequestDto
            {
                NamePrefix = "São",
                Limit = 2
            };

            // Act
            var result = await _citySearchService.SearchCitiesAsync(request);

            // Assert
            result.ShouldNotBeNull();
            // Puede devolver resultados o vacío, pero no debería fallar 
        }
    }
}