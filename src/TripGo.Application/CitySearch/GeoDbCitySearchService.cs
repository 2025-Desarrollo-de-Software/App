using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using TripGo.CitySearch;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;


namespace TripGo.CitySearch
{
    public class GeoDbCitySearchService : ICitySearchService
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiKey;
        private readonly string _baseUrl;

        public GeoDbCitySearchService(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _apiKey = configuration["GeoDBApi:ApiKey"] ?? "0be1445139msh1edee90d063f40ep100d0cjsnc9ad21f0b939";
            _baseUrl = configuration["GeoDBApi:BaseUrl"] ?? "https://wft-geo-db.p.rapidapi.com/v1/geo";

            _httpClient.DefaultRequestHeaders.Clear();
            _httpClient.DefaultRequestHeaders.Add("X-RapidAPI-Key", _apiKey);
            _httpClient.DefaultRequestHeaders.Add("X-RapidAPI-Host", "wft-geo-db.p.rapidapi.com");
        }

        public async Task<CitySearchResultDto> SearchCitiesAsync(CitySearchRequestDto request)
        {
            if (string.IsNullOrWhiteSpace(request.NamePrefix))
            {
                return new CitySearchResultDto { Cities = new List<CityDto>() };
            }

            try
            {
                string url = $"{_baseUrl}/cities?namePrefix={Uri.EscapeDataString(request.NamePrefix)}&limit={request.Limit}";

                HttpResponseMessage response = await _httpClient.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    string jsonResult = await response.Content.ReadAsStringAsync();

                    // ✅ Ahora usa GeoDbApiResponse (clase interna)
                    var apiResponse = JsonSerializer.Deserialize<GeoDbApiResponse>(
                        jsonResult,
                        new JsonSerializerOptions { PropertyNameCaseInsensitive = true }
                    );

                    return new CitySearchResultDto
                    {
                        Cities = MapToCityDtos(apiResponse)
                    };
                }
                else
                {
                    throw new ApplicationException($"Error en la API: {response.StatusCode}");
                }
            }
            catch (Exception ex)
            {
                throw new ApplicationException($"Error buscando ciudades: {ex.Message}", ex);
            }
        }

        private List<CityDto> MapToCityDtos(GeoDbApiResponse apiResponse)
        {
            var cities = new List<CityDto>();

            if (apiResponse?.data == null) return cities;

            foreach (var cityData in apiResponse.data)
            {
                cities.Add(new CityDto
                {
                    Id = cityData.id,
                    Name = cityData.name,
                    Country = cityData.country,
                    Latitude = cityData.latitude,
                    Longitude = cityData.longitude,
                    Population = cityData.population
                });
            }

            return cities;
        }
    }

    // ✅ CLASES INTERNAS PARA DESERIALIZACIÓN
    internal class GeoDbApiResponse
    {
        public List<GeoDbApiData> data { get; set; }
    }

    internal class GeoDbApiData
    {
        public int id { get; set; }
        public string name { get; set; }
        public string country { get; set; }
        public string countryCode { get; set; }
        public string region { get; set; }
        public double latitude { get; set; }
        public double longitude { get; set; }
        public int? population { get; set; }
    }

}