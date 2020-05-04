import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { ServiceDto } from 'src/app/models/service.model';
import { ServiceService } from 'src/app/services/service.service';

@Component({
  selector: 'app-avaiable-services',
  templateUrl: './avaiable-services.component.html',
  styleUrls: ['./avaiable-services.component.scss']
})
export class AvaiableServicesComponent implements OnInit {

  @Input() selectedServices: ServiceDto[];
  services: ServiceDto[]

  constructor(private _serviceService: ServiceService) { }

  ngOnInit(): void {
    this._serviceService.getServices().subscribe(resp =>{
      this.services = resp
    })
  }

  selectService(service: ServiceDto) {
    var index =this.services.indexOf(service);
    if(this.services[index].isSelected) {
      //Odznaczamy serwis
      this.services[index].isSelected = false
      var indexInSelected =this.selectedServices.indexOf(service);
      this.selectedServices.splice(indexInSelected, 1);

    } else {
      //Zaznaczamys serwis
      this.services[index].isSelected = true
      this.selectedServices.push(this.services[index])
    }
    console.log(this.selectedServices)
    
  }

}
