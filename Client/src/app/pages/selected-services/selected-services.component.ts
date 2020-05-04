import { Component, OnInit, Input, OnChanges } from '@angular/core';
import { ServiceDto } from 'src/app/models/service.model';
import { ServiceService } from 'src/app/services/service.service';
import { PaymentService } from 'src/app/services/payment.service';

@Component({
  selector: 'app-selected-services',
  templateUrl: './selected-services.component.html',
  styleUrls: ['./selected-services.component.scss']
})
export class SelectedServicesComponent implements OnInit, OnChanges{

  @Input() selectedServices: ServiceDto[];
  idToOrder : string[] = []
 
  constructor(private _serviceService: ServiceService,
      private _paymentService: PaymentService) { }
  
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
  order(): void{
    this.selectedServices.forEach(service =>{
      this.idToOrder.push(service.id);
    })
    this._serviceService.orderServices(this.idToOrder).subscribe({
      next:data => this._paymentService.orderByPayU(),
      error: error => console.log("error" + error)
    })
    
  }

}
