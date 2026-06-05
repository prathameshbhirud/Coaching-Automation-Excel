import { HttpClient } from "@angular/common/http";
import { inject, Injectable } from "@angular/core";
import { environment } from "../../../environments/environment";

@Injectable({
  providedIn: 'root'
})
export class ReportsService {

  private http = inject(HttpClient);

  private baseUrl = `${environment.apiUrl}/reports`;

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