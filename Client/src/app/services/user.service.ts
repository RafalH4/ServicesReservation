import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class UserService {
  baseUrl = 'https://localhost:44300/user/';
  constructor(private http: HttpClient) { }

  addAdmin(user: any){
    return this.http.post(this.baseUrl+'registerAdmin', user)
  }

  addClient(user: any){
    return this.http.post(this.baseUrl+'registerClient', user)
  }

  getProviders(): Observable<any>{
    return this.http.get(this.baseUrl+'allClients')
  }
}
