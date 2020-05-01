import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { ServiceDto } from 'src/app/models/service.model';

@Component({
  selector: 'app-avaiable-services',
  templateUrl: './avaiable-services.component.html',
  styleUrls: ['./avaiable-services.component.scss']
})
export class AvaiableServicesComponent implements OnInit {

  @Input() services: ServiceDto[];
  @Output() selectedService = new EventEmitter<ServiceDto>();

  constructor() { }

  ngOnInit(): void {
  }

  selectService(service: ServiceDto, event) {
    this.selectedService.emit(service);

    var index =this.services.indexOf(service);
    if(this.services[index].isSelected) {
      //wybrane
      this.services[index].isSelected = false;
    } else {
      //wolne
      this.services[index].isSelected = true;
    } 
    this.services[index].isSelected != this.services[index].isSelected    
  }

}
