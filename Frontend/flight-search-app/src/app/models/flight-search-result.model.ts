export interface FlightOfferData {
    departureAirport: string;
    arrivalAirport: string;
    departureDate: string;
    returnDate?: string;
    numberOfTransfersDeparture: number;
    numberOfTransfersReturn?: number;
    passengerCount: number;
    currency: string;
    totalPrice: string;
  }
  