import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

import { environment }
from '../../../environments/environment';

@Injectable({
  providedIn: 'root'
})
export class LogsService {

  private http = inject(HttpClient);

  private baseUrl = `${environment.apiUrl}/logs`;

  getRecent(){
    return this.http.get(`${this.baseUrl}/recent`);
  }
}