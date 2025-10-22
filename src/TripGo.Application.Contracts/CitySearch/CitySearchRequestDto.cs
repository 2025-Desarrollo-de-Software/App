using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;

namespace TripGo.CitySearch
{
    public class CitySearchRequestDto
    {
        public string NamePrefix { get; set; } 
        public int Limit { get; set; } = 10;
        public List<CityDto> Cities { get; set; } = new();
    }
}
