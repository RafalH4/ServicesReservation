import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ItemService {
  baseUrl = 'https://localhost:44300/itemService/';

  constructor(private http: HttpClient) { }

  addItem(item: any){
    return this.http.post(this.baseUrl, item)
  }
  getItems(): Observable<any>{
    return this.http.get(this.baseUrl+'all')
  }
  get(id):Observable<any>{
    return this.http.get(this.baseUrl+'id/'+id)
  }
  remove(id: any){
    return this.http.delete(this.baseUrl+id)
  }

  
}
