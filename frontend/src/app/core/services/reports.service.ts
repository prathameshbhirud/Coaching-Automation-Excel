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

  exportAttendance() {
    return this.http.get(`${this.baseUrl}/attendance/export`,{ responseType: 'blob' });
  }

  exportFees() {
    return this.http.get(`${this.baseUrl}/fees/export`, { responseType: 'blob' });
  }

  exportExams() {
    return this.http.get(`${this.baseUrl}/exams/export`, { responseType: 'blob' });
  }

  exportBroadcast() {
    return this.http.get(`${this.baseUrl}/broadcast/export`, { responseType: 'blob' });
  }

  exportAttendancePdf() {
    return this.http.get(`${this.baseUrl}/attendance/pdf`, { responseType: 'blob' });
  }

  exportFeesPdf() {
    return this.http.get(`${this.baseUrl}/fees/pdf`, { responseType: 'blob' });
  }

  exportExamsPdf() {
    return this.http.get(`${this.baseUrl}/exams/pdf`, { responseType: 'blob' });
  }

  exportBroadcastPdf() {
    return this.http.get(`${this.baseUrl}/broadcast/pdf`, { responseType: 'blob' });
  }
}