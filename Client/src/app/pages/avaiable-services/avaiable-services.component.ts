import { Component, OnInit, Input } from '@angular/core';
import { ServiceDto } from 'src/app/models/service.model';

@Component({
  selector: 'app-avaiable-services',
  templateUrl: './avaiable-services.component.html',
  styleUrls: ['./avaiable-services.component.scss']
})
export class AvaiableServicesComponent implements OnInit {

  @Input() services: ServiceDto[];
  constructor() { }

  ngOnInit(): void {
  }

}
