import { Component, OnInit, Input, OnChanges } from '@angular/core';
import { ServiceDto } from 'src/app/models/service.model';

@Component({
  selector: 'app-selected-services',
  templateUrl: './selected-services.component.html',
  styleUrls: ['./selected-services.component.scss']
})
export class SelectedServicesComponent implements OnInit, OnChanges{

  @Input() selectedServices: ServiceDto[];
 
  constructor() { }
  
  ngOnChanges(): void {
    console.log("Ja się zmieniam");
    console.log(this.selectedServices)
  }

  ngOnInit(): void {
  }
  removeService(index: number){
    this.selectedServices[index].isSelected=false;
    this.selectedServices.splice(index, 1)
  }

}
