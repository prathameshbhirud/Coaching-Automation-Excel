import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from '../../../environments/environment';

@Injectable({
  providedIn: 'root'
})
export class NotificationService {

  private http = inject(HttpClient);

  private baseUrl = `${environment.apiUrl}/run`;

  runAttendance() {
    return this.http.get(`${this.baseUrl}/attendance`);
  }

  runFees() {
    return this.http.get(`${this.baseUrl}/fees`);
  }

  runExams() {
    return this.http.get(`${this.baseUrl}/exams`);
  }

  runBroadcast() {
    return this.http.get(`${this.baseUrl}/broadcast`);
  }
}