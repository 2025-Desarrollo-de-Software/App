using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;

namespace TripGo.CitySearch
{
    public class CitySearchResultDto
    {
        public List<CityDto> Cities { get; set; }
    }
}
