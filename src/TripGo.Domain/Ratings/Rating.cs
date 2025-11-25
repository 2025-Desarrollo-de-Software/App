using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities;

namespace TripGo.Ratings
{
    public class Rating : Entity<Guid>, IUserOwned
    {
        public Guid UserId { get; set; }
        public Guid DestinationId { get; set; }
        public int Score { get; set; }
        public string Comment { get; set; }
        public DateTime CreationTime { get; set; }

        protected Rating() { }

        public Rating(Guid id, Guid userId, Guid destinationId, int score, string comment = null)
        {
            Id = id;
            UserId = userId;
            DestinationId = destinationId;
            Score = score;
            Comment = comment;
            CreationTime = DateTime.Now;
        }
    }
}
