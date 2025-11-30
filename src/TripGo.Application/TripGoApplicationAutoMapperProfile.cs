using AutoMapper;
using TripGo.Ratings;

namespace TripGo;

public class TripGoApplicationAutoMapperProfile : Profile
{
    public TripGoApplicationAutoMapperProfile()
    {
        /* You can configure your AutoMapper mapping configuration here.
         * Alternatively, you can split your mapping configurations
         * into multiple profile classes for a better organization. */
       CreateMap<Destinations.Destination, Destinations.DestinationDTO>();
       CreateMap<Destinations.CreateUpdateDestinationDto, Destinations.Destination>();
       CreateMap<Rating, RatingDto>();
    }
}
