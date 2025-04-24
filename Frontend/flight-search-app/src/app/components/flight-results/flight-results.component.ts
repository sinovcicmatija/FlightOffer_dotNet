import { Component, Input } from '@angular/core';
import { FlightOfferData } from '../../models/flight-search-result.model';

export const currencySymbols: { [key: string]: string } = {
  USD: '$',
  EUR: '€',
  HRK: 'kn',
};

@Component({
  selector: 'app-flight-results',
  standalone: false,
  templateUrl: './flight-results.component.html',
  styleUrl: './flight-results.component.scss'
})
export class FlightResultsComponent {

  @Input() offers: FlightOfferData[] = [];

  currencySymbols = currencySymbols;

  displayedColumns: string[] = [
    'departureAirport',
    'arrivalAirport',
    'dates',
    'transfers',
    'passengerCount',
    'currency',
    'totalPrice'
  ];
  

}
