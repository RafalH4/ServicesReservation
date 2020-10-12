import { Component, OnInit } from '@angular/core';
import { DashboardDataService } from 'src/app/services/dashboard-data.service';
import { ItemService } from 'src/app/services/item.service';

@Component({
  selector: 'app-services',
  templateUrl: './services.component.html',
  styleUrls: ['./services.component.scss']
})
export class ServicesComponent implements OnInit {
  title = "Świadczone usługi"
  items = [];

  constructor(private dashboardData: DashboardDataService,
    private itemService: ItemService) { }

  ngOnInit(): void {
    this.dashboardData.setTitle(this.title)
    // this.itemService.getItems().subscribe(resp =>{
    //   this.items = resp;
    //   console.log(resp)
    // })
  }

}
