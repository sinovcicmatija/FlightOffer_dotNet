import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { FlightOfferData } from './models/flight-search-result.model';

@Component({
  selector: 'app-root',
  standalone: false,
  templateUrl: './app.component.html',
  styleUrl: './app.component.scss'
})
export class AppComponent {
  title = 'Angular-app';

  flightResults: FlightOfferData[] = [];

  handleResults(results: FlightOfferData[]) {
    this.flightResults = results;
  }
}