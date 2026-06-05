import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

import { environment } from '../../../environments/environment';

@Injectable({
  providedIn: 'root'
})
export class StatisticsService {

  private http = inject(HttpClient);

  private baseUrl = `${environment.apiUrl}/statistics`;

  getStats(){
    return this.http.get(this.baseUrl);
  }

  getAttendanceTrend() {
    return this.http.get(`${this.baseUrl}/attendance-trend`);
  }
}