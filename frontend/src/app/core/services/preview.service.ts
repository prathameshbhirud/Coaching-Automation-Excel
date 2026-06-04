import { Injectable, inject } from '@angular/core';

import { HttpClient } from '@angular/common/http';

import { environment } from '../../../environments/environment';

@Injectable({
  providedIn: 'root'
})
export class PreviewService {

  private http = inject(HttpClient);

  private baseUrl = `${environment.apiUrl}/preview`;

  attendance() {
    return this.http.get(`${this.baseUrl}/attendance`);
  }

  fees() {
    return this.http.get(`${this.baseUrl}/fees`);
  }

  exams() {
    return this.http.get(`${this.baseUrl}/exams`);
  }

  broadcast() {
    return this.http.get(`${this.baseUrl}/broadcast`);
  }
}