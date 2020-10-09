import { Injectable } from '@angular/core';
import { Subject } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class DashboardDataService {
  private actualTitle = new Subject<string>()

  actualTitle$ = this.actualTitle.asObservable();

  setTitle(title: string){
    this.actualTitle.next(title);
  }
  getTitle(){
    return this.actualTitle$;
  }

  constructor() { }
}
