namespace FlightSearch.Models.DTOs
{
    public class FlightOfferDTO
    {
        public string? DepartureAirport { get; set; }
        public string? ArrivalAirport { get; set; }
        public string? DepartureDate { get; set; }
        public string? ReturnDate { get; set; }
        public int NumberOfTransfersDeparture { get; set; }
        public int NumberOfTransfersReturn { get; set; }
        public int PassengerCount { get; set; }
        public string? Currency { get; set; }
        public string? TotalPrice { get; set; }
    }
}
