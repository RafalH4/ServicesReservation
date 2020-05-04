import { Component, OnInit, OnChanges } from '@angular/core';
import { ServiceService } from 'src/app/services/service.service';
import { Observable } from 'rxjs';
import { ServiceDto } from 'src/app/models/service.model';

@Component({
  selector: 'app-main-page',
  templateUrl: './main-page.component.html',
  styleUrls: ['./main-page.component.scss']
})
export class MainPageComponent implements OnInit, OnChanges {


  services$: Observable<ServiceDto[]>
  selectedServices: ServiceDto[] = []
  services = {
    allServices: this.services$,
    selectedServices: this.selectedServices
  }

  constructor() { }
  ngOnChanges(): void {
    console.log("Działam")
  }


  ngOnInit(): void {
  }
  
}
