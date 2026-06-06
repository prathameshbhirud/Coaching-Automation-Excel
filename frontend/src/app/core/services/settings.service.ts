import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

import { Observable } from 'rxjs';

import { SettingsModel } from '../models/settings.model';

@Injectable({
  providedIn: 'root'
})
export class SettingsService {

  private readonly api = 'http://localhost:5110/api/settings';

  constructor(private http: HttpClient) { }

  get(): Observable<SettingsModel> {
    return this.http.get<SettingsModel>(this.api);
  }

  save(model: SettingsModel) {
    return this.http.post(this.api, model);
  }
}