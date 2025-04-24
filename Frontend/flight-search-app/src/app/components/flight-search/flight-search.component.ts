import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { FormControl } from '@angular/forms';
import { debounceTime, distinctUntilChanged, filter, switchMap, Observable } from 'rxjs';
import { AirportData } from '../../models/airport-data.model';
import { ApiService } from '../../services/api.service';
import { FlightSearchDTO } from '../../models/flight-search-call.model';
import { FlightOfferData } from '../../models/flight-search-result.model';

@Component({
  standalone: false,
  selector: 'app-flight-search',
  templateUrl: './flight-search.component.html',
  styleUrls: ['./flight-search.component.scss']
})
export class FlightSearchComponent implements OnInit {
  departureControl = new FormControl();
  destinationControl = new FormControl();

  departureAirports$: Observable<AirportData[]> | null = null;
  destinationAirports$: Observable<AirportData[]> | null = null;

  selectedDepartureIata: string | null= null;
  selectedDestinationIata: string | null = null;

  isRoundTrip = false;
  departureDate: Date | null = null;
  returnDate: Date | null = null;
  travelerBoxVisible = false;
  adults = 1;
  children = 0;
  cabinClass = 'ECONOMY';
  cabinClasses = ['ECONOMY', 'PREMIUM_ECONOMY', 'BUSINESS', 'FIRST'];
  currency = 'USD';
  currencyes = ['USD', 'EUR', 'HRK'];

  @Output() resultsFound = new EventEmitter<FlightOfferData[]>();


  constructor(private apiService: ApiService) {}

  ngOnInit(): void {
    this.departureAirports$ = this.departureControl.valueChanges.pipe(
      debounceTime(500),
      distinctUntilChanged(),
      filter(value => typeof value === 'string' && value.trim().length > 0),
      switchMap(value => this.apiService.getAirportData(value))
    );
  
    this.destinationAirports$ = this.destinationControl.valueChanges.pipe(
      debounceTime(500),
      distinctUntilChanged(),
      filter(value => typeof value === 'string' && value.trim().length > 0),
      switchMap(value => this.apiService.getAirportData(value))
    );
  }

  onDepartureSelected(event: any): void {
    const selectedAirport: AirportData = event.option.value;
    console.log("Polazak:", selectedAirport);
    this.selectedDepartureIata = selectedAirport.iataCode;
  }
  
  onDestinationSelected(event: any): void {
    const selectedAirport: AirportData = event.option.value;
    console.log("Odredište:", selectedAirport);
    this.selectedDestinationIata = selectedAirport.iataCode;
  }
  

  displayFn(airport: AirportData | null): string {
    return airport ? `${airport.cityName}, ${airport.airportName} (${airport.iataCode})` : '';
  }

  toggleRoundTrip(): void {
    if (!this.isRoundTrip) {
      this.returnDate = null;
    }
  }

  toggleTravelerBox() {
    this.travelerBoxVisible = !this.travelerBoxVisible;
  }

  adjustCount(type: 'adults' | 'children', change: number) {
    if (type === 'adults') this.adults = Math.max(1, this.adults + change);
    if (type === 'children') this.children = Math.max(0, this.children + change);
  }

  
getTravelerSummary(): string {
  const total = this.adults + this.children;
  const label = total === 1 ? 'Putnik' : 'Putnika';
  return`${total} ${label}, ${this.cabinClass}`;
}

formatDate(date: Date): string {
  const year = date.getFullYear();
  const month = `${date.getMonth() + 1}`.padStart(2, '0');
  const day = `${date.getDate()}`.padStart(2, '0');
  return `${year}-${month}-${day}`;
}


getFlightOfferData()
{    
  if (!this.selectedDepartureIata || !this.selectedDestinationIata || !this.departureDate) {
    alert('Molimo ispunite sve obavezne podatke.');
    return;
  }
  const searchDTO: FlightSearchDTO = {
    originIata: this.selectedDepartureIata || '',
    destinationIata: this.selectedDestinationIata || '',
    departureDate: this.formatDate(this.departureDate),
    returnDate: this.isRoundTrip && this.returnDate? this.formatDate(this.returnDate) : undefined,
    isRoundTrip: this.isRoundTrip,
    adults: this.adults,
    children: this.children,
    cabinClass: this.cabinClass,
    currency: this.currency
  }
  this.apiService.getFlightOfferData(searchDTO).subscribe({
    next: (offers) => this.resultsFound.emit(offers),
    error: (err) => console.error('Greška:', err)
  });
}
}
