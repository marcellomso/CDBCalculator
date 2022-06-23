import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';
import { Observable } from 'rxjs';

import { SendData } from '../model/send-data';
import { ReturnData } from '../model/return-data';

@Injectable({
  providedIn: 'root'
})
export class CalcService {
  private readonly baseUrl: string;
  private readonly httpClient: HttpClient;

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.baseUrl = baseUrl;
    this.httpClient = http;
   }

  public calcInvestment(data: SendData): Observable<ReturnData> {
    const httpOptions = {
      headers: new HttpHeaders({
        'Content-Type': 'application/json'
      })
    };

    return this.httpClient.post<ReturnData>(this.baseUrl+'calculateInvestment', data, httpOptions).pipe();
  }
}
