import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ServiceService {
  baseUrl = 'https://localhost:44300/service';

  constructor(private http: HttpClient) { }

  getServices() : Observable<any>{
    return this.http.get(this.baseUrl + '/getServices')
  }

  orderServices(ids: string[]) : Observable<any>{
    return this.http.post(this.baseUrl + '/bookOrder', ids)
  }


}
