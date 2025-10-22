using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TripGo.CitySearch;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace TripGo.Destinations
{
        public class DestinationAppService : CrudAppService<
            Destination,
            DestinationDTO,
            Guid,
            PagedAndSortedResultRequestDto,
            CreateUpdateDestinationDto>,
            IDestinationAppService

       {
            private readonly ICitySearchService _citySearchService;
            public DestinationAppService(IRepository<Destination,Guid> repository, ICitySearchService citySearchService )
                : base(repository)
            {
                _citySearchService = citySearchService;
        }
           public async Task<CitySearchResultDto> SearchCitiesAsync(CitySearchRequestDto request)
           {
               return await _citySearchService.SearchCitiesAsync(request);
        }
    }
    }

