using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;

namespace TripGo.Ratings
{
    public class RatingDto : EntityDto<Guid>
    {
        public Guid UserId { get; set; }
        public Guid DestinationId { get; set; }
        public int Score { get; set; }
        public string Comment { get; set; }
        public DateTime CreationTime { get; set; }
    }
}
