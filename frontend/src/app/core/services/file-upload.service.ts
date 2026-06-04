import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from '../../../environments/environment';

@Injectable({
  providedIn: 'root'
})
export class FileUploadService {

  private http = inject(HttpClient);

  private baseUrl = `${environment.apiUrl}/files`;

  uploadAttendance(file: File) {

    const formData = new FormData();
    formData.append('file', file);
    return this.http.post(`${this.baseUrl}/attendance`, formData);
  }

  uploadFees(file: File) {
    const formData = new FormData();
    formData.append('file', file);
    return this.http.post(`${this.baseUrl}/fees`, formData);
  }

  uploadExams(file: File) {
    const formData = new FormData();
    formData.append('file', file);
    return this.http.post(`${this.baseUrl}/exams`, formData);
  }

  uploadBroadcast(file: File) {
    const formData = new FormData();
    formData.append('file', file);
    return this.http.post(`${this.baseUrl}/broadcast`, formData);
  }
}