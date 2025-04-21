import { Component, Input } from '@angular/core';
import { FlightOfferData } from '../../models/flight-search-result.model';

@Component({
  selector: 'app-flight-results',
  standalone: false,
  templateUrl: './flight-results.component.html',
  styleUrl: './flight-results.component.scss'
})
export class FlightResultsComponent {

  @Input() offers: FlightOfferData[] = [];

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
