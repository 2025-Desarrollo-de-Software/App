using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TripGo.Ratings
{
    public class RateDestinationDto
    {
        public Guid DestinationId { get; set; }
        public int Score { get; set; }
        public string Comment { get; set; }
    }
}
