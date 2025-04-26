using FlightSearch.Models.DTOs;
using FlightSearch.Models.External;
using FlightSearch.Models.External.SubModel;
using System.Threading.Tasks.Dataflow;

namespace FlightSearch.Helpers
{
    public class FlightOfferCallMapper
    {
        public static FlightOfferCallModel MapToFlightOfferCallModel(FlightOfferCallDTO dto)
        {
            var originDestinations = new List<OriginDestinations>()
            {
                new OriginDestinations
                {
                    Id = "1",
                    OriginLocationCode = dto.OriginIata,
                    DestinationLocationCode = dto.DestinationIata,
                    DepartureDateTimeRange = new DepartureDateTimeRange
                    {
                        Date = dto.DepartureDate
                    }
                }
            };

            if(dto.IsRoundTrip && dto.ReturnDate != null)
            {
                originDestinations.Add(new OriginDestinations
                {
                    Id = "2",
                    OriginLocationCode = dto.DestinationIata,
                    DestinationLocationCode = dto.OriginIata,
                    DepartureDateTimeRange = new DepartureDateTimeRange
                    {
                        Date = dto.ReturnDate
                    }
                }); 
            }

            var travelers = new List<Travelers>();
            for(int i = 0; i < dto.Adults; i++) 
                travelers.Add(new Travelers { Id = (i + 1).ToString(), TravelerType = "ADULT" });
            for (int i = 0; i < dto.Children; i++)
                travelers.Add(new Travelers { Id = (dto.Adults + i + 1).ToString(), TravelerType = "CHILD" });

            return new FlightOfferCallModel
            {
                CurrencyCode = dto.Currency,
                OriginDestinations = originDestinations,
                Travelers = travelers,
                Sources = ["GDS"],
                SearchCriteria = new SearchCriteria
                {
                    MaxFlightOffers = 250,
                    FlightFilters = new FlightFilters
                    {
                        CabinRestrictions = new List<CabinRestrictions>
                        {
                            new CabinRestrictions
                            {
                                Cabin = dto.CabinClass.ToUpper(),
                                Coverage = "MOST_SEGMENTS",
                                OriginDestinationIds = originDestinations.Select(o => o.Id!).ToList()
                            }
                        }
                    }
                }
            };

        }
    }
}
