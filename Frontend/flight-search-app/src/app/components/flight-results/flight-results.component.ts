import { Component, Input, ViewChild, AfterViewInit } from '@angular/core';
import { MatPaginator, PageEvent } from '@angular/material/paginator';
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
export class FlightResultsComponent implements AfterViewInit {

  @Input() set offers(data: FlightOfferData[]) {
    if(!data || data.length === 0) {
      alert("Nema dostupnih letova za odabrane parametre.")
      return;
    }
    this.fullOffers = data.sort((a, b) => {
      const aDate = this.parseDate(a.departureDate);
      const bDate = this.parseDate(b.departureDate);
      return aDate.getTime() - bDate.getTime();
    });
    this.updatePagedData();
  }

  private parseDate(dateStr: string): Date {
    const regex = /(\d{2})\.(\d{2})\.(\d{4})\. u (\d{2}):(\d{2})/;
    const match = dateStr.match(regex);
  
    if (!match) return new Date(); 
  
    const [_, day, month, year, hours, minutes] = match;
    return new Date(Number(year), Number(month) - 1, Number(day), Number(hours), Number(minutes));
  }

  fullOffers: FlightOfferData[] = [];
  pagedOffers: FlightOfferData[] = [];

  pageSize = 10;
  pageIndex = 0;
  length = 0;

  currencySymbols = currencySymbols;

  @ViewChild(MatPaginator) paginator!: MatPaginator;

  ngAfterViewInit(): void {
    this.length = this.fullOffers.length;
    this.updatePagedData();
  }

  onPageChange(event: PageEvent): void {
    this.pageSize = event.pageSize;
    this.pageIndex = event.pageIndex;
    this.updatePagedData();
  }

  private updatePagedData(): void {
    const start = this.pageIndex * this.pageSize;
    const end = start + this.pageSize;
    this.pagedOffers = this.fullOffers.slice(start, end);
  }

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
