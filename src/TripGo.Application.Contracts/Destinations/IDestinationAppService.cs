using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace TripGo.Destinations
{
    public interface IDestinationAppService :
        ICrudAppService<//Defines CRUD methods
        DestinationDTO, //Used to show destinations
        Guid, //Primary key of the destination entity
        PagedAndSortedResultRequestDto, //Used for paging/sorting
        CreateUpdateDestinationDto> //Used to create/update a destination

  
    {

    }
}
