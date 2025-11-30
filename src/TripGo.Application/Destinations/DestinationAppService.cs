using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            public DestinationAppService(IRepository<Destination,Guid> repository)
                : base(repository)
            {

            }
        }
    }

