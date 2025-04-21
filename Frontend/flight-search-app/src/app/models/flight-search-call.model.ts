export interface FlightSearchDTO {
    originIata: string;
    destinationIata: string;
    departureDate: string;
    returnDate?: string;
    isRoundTrip: boolean;
    adults: number;
    children: number;
    cabinClass: string;
    currency: string;
  }
  