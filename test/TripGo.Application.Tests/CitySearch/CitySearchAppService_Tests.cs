using Moq;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TripGo.CitySearch;
using Xunit;

namespace TripGo.CitySearch
{
    public class CitySearchAppService_Tests : TripGoApplicationTestBase<TripGoApplicationModule>
    {
        private readonly CitySearchAppService _citySearchAppService;
        private readonly Mock<ICitySearchService> _mockCitySearchService;

        public CitySearchAppService_Tests()
        {
            _mockCitySearchService = new Mock<ICitySearchService>();
            _citySearchAppService = new CitySearchAppService(_mockCitySearchService.Object);
        }

        [Fact]
        public async Task SearchAsync_WithValidName_ShouldReturnCities()
        {
            // Arrange
            var expectedCities = new List<CityDto>
            {
                new CityDto { Id = 1, Name = "Buenos Aires", Country = "Argentina" },
                new CityDto { Id = 2, Name = "Córdoba", Country = "Argentina" }
            };

            var expectedResult = new CitySearchResultDto { Cities = expectedCities };

            _mockCitySearchService
                .Setup(x => x.SearchCitiesAsync(It.IsAny<CitySearchRequestDto>()))
                .ReturnsAsync(expectedResult);

            // Act
            var result = await _citySearchAppService.SearchAsync("Buenos");

            // Assert
            result.ShouldNotBeNull();
            result.Cities.ShouldNotBeNull();
            result.Cities.Count.ShouldBe(2);
            result.Cities[0].Name.ShouldBe("Buenos Aires");
        }

        [Fact]
        public async Task SearchAsync_WithEmptyName_ShouldReturnEmptyList()
        {
            // Arrange
            var expectedResult = new CitySearchResultDto { Cities = new List<CityDto>() };

            _mockCitySearchService
                .Setup(x => x.SearchCitiesAsync(It.IsAny<CitySearchRequestDto>()))
                .ReturnsAsync(expectedResult);

            // Act
            var result = await _citySearchAppService.SearchAsync("");

            // Assert
            result.ShouldNotBeNull();
            result.Cities.ShouldBeEmpty();
        }

        [Fact]
        public async Task SearchAsync_WhenServiceThrowsException_ShouldPropagateException()
        {
            // Arrange
            _mockCitySearchService
                .Setup(x => x.SearchCitiesAsync(It.IsAny<CitySearchRequestDto>()))
                .ThrowsAsync(new ApplicationException("API Error"));

            // Act & Assert
            await Should.ThrowAsync<ApplicationException>(async () =>
            {
                await _citySearchAppService.SearchAsync("Test");
            });
        }

        [Fact]
        public async Task SearchAsync_WithLimitParameter_ShouldPassLimitToService()
        {
            // Arrange
            var expectedResult = new CitySearchResultDto { Cities = new List<CityDto>() };
            CitySearchRequestDto capturedRequest = null;

            _mockCitySearchService
                .Setup(x => x.SearchCitiesAsync(It.IsAny<CitySearchRequestDto>()))
                .Callback<CitySearchRequestDto>(request => capturedRequest = request)
                .ReturnsAsync(expectedResult);

            // Act
            await _citySearchAppService.SearchAsync("Madrid", 5);

            // Assert
            capturedRequest.ShouldNotBeNull();
            capturedRequest.NamePrefix.ShouldBe("Madrid");
            capturedRequest.Limit.ShouldBe(5);
        }
    }
}