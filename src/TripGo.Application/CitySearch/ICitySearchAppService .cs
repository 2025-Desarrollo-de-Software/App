using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace TripGo.CitySearch
{
    public interface ICitySearchAppService : IApplicationService
    {
        Task<CitySearchResultDto> SearchAsync(string namePrefix, int limit = 10);
    }

    public class CitySearchAppService : ApplicationService, ICitySearchAppService
    {
        private readonly ICitySearchService _citySearchService;

        public CitySearchAppService(ICitySearchService citySearchService)
        {
            _citySearchService = citySearchService;
        }

        public async Task<CitySearchResultDto> SearchAsync(string namePrefix, int limit = 10)
        {
            // Crear el request
            var request = new CitySearchRequestDto
            {
                NamePrefix = namePrefix,
                Limit = limit
            };

            // Llamar al servicio
            return await _citySearchService.SearchCitiesAsync(request);
        }
    }
}