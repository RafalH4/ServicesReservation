import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ProvidersService {
  baseUrl = 'https://localhost:44300/user/';

  constructor(private http: HttpClient) { }

  getProviders(): Observable<any>{
    return this.http.get(this.baseUrl+'allClients')
  }

}
