using System.Globalization;
using FlightSearch.Models.Domain;
using FlightSearch.Models.Domain.SubModel;
using FlightSearch.Models.DTOs;

namespace FlightSearch.Helpers
{
    public class FlightOfferMapper
    {
        private static string FormatDateTime(string isoDateTime)
        {
            if (DateTime.TryParse(isoDateTime, out var parsedDate))
            {
                return parsedDate.ToString("dd.MM.yyyy. 'u' HH:mm", CultureInfo.InvariantCulture);
            }
            return isoDateTime; 
        }
        public static List<FlightOfferDTO> toDTO(FlightOfferResponse response)
        {
            List<FlightOfferDTO> dtoList = new List<FlightOfferDTO> ();

            foreach(FlightData flightData in response.Data)
            {
                bool isRoundTrip = flightData.Itineraries.Length == 2;
                FlightOfferDTO dto = new FlightOfferDTO();

                var itineraries = flightData.Itineraries;
                if(itineraries.Length > 0)
                {
                    var segments = itineraries[0].Segments;
                    if(segments?.Length > 0)
                    {
                        var departure = segments[0].Departure;
                        if(departure != null)
                        {
                            dto.DepartureAirport = departure.IataCode;
                        }
                    }
                }

                if(itineraries.Length > 0)
                {
                    var segments = itineraries[0].Segments;
                    if(segments?.Length > 0)
                    {
                        var arrival = segments[segments.Length - 1].Arrival;
                        if(arrival != null)
                        {
                            dto.ArrivalAirport = arrival.IataCode;
                        }
                    }
                }

                if (itineraries.Length > 0)
                {
                    var segments = itineraries[0].Segments;
                    if (segments?.Length > 0)
                    {
                        var departureDate = segments[0].Departure;
                        if (departureDate != null)
                        {
                            dto.DepartureDate = FormatDateTime(departureDate.At);
                        }
                    }
                }
                if(isRoundTrip) 
                {
                    if (itineraries.Length > 1)
                    {
                        var segments = itineraries[1].Segments;
                        if (segments?.Length > 0)
                        {
                            var returnDate = segments[segments.Length - 1].Arrival;
                            if (returnDate != null)
                            {
                                dto.ReturnDate = FormatDateTime(returnDate.At);
                            }
                        }
                    }
                }

                if (itineraries.Length > 0)
                {
                    var segments = itineraries[0].Segments;
                    if (segments?.Length > 0)
                    {
                        dto.NumberOfTransfersDeparture = segments.Length - 1;
                    }
                }

                if(isRoundTrip)
                {
                    var segments = itineraries[1].Segments;
                    if (segments?.Length > 0)
                    {
                        dto.NumberOfTransfersReturn = segments.Length - 1;
                    }
                }

                if(flightData.TravelerPricings != null)
                {
                    dto.PassengerCount = flightData.TravelerPricings.Length;
                }

                if(flightData.Price != null)
                {
                    dto.Currency = flightData.Price.Currency;
                    dto.TotalPrice = flightData.Price.GrandTotal;
                }
                dtoList.Add(dto);
            }
            return dtoList;
        }
    }
}
