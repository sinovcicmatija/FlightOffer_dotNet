import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { AirportData } from '../models/airport-data.model';
import { FlightSearchDTO } from '../models/flight-search-call.model';
import { FlightOfferData } from '../models/flight-search-result.model';
import { environment } from '../../environments/environment';

const apiUrl = environment.apiUrl;

@Injectable({
  providedIn: 'root'
})
export class ApiService {
  constructor(private http: HttpClient) {}

  getAirportData(keyword: string): Observable<AirportData[]> {
    return this.http.get<AirportData[]>(`${apiUrl}/Airport/airports?keyword=${keyword}`);
  }

  getFlightOfferData(searchData: FlightSearchDTO): Observable<FlightOfferData[]> {
    return this.http.post<FlightOfferData[]>(`${apiUrl}/FlightOffer/flight-offers`, searchData);
  }
}
