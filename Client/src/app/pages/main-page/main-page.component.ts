import { Component, OnInit } from '@angular/core';
import { ServiceService } from 'src/app/services/service.service';
import { Observable } from 'rxjs';
import { ServiceDto } from 'src/app/models/service.model';

@Component({
  selector: 'app-main-page',
  templateUrl: './main-page.component.html',
  styleUrls: ['./main-page.component.scss']
})
export class MainPageComponent implements OnInit {

  services$: Observable<ServiceDto[]>

  constructor(private _serviceService: ServiceService) { }

  ngOnInit(): void {
    this._serviceService.getServices().subscribe(resp =>{
      this.services$ = resp
      console.log(this.services$)
    })
  }

}
