using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace TripGo.Ratings
{
    public interface IRatingAppService : IApplicationService
    {
        Task<RatingDto> RateDestinationAsync(RateDestinationDto input);
        Task<ListResultDto<RatingDto>> GetUserRatingsAsync();
        Task DeleteRatingAsync(Guid id);
    }
}
