import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { ServiceDto } from '../models/service.model';

@Injectable({
  providedIn: 'root'
})
export class ServiceService {
  baseUrl = 'https://localhost:44300/service/getservices';

  constructor(private http: HttpClient) { }

  getServices() : Observable<any>{
    return this.http.get(this.baseUrl + '')
  }


}
