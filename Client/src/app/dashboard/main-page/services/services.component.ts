import { Component, OnInit } from '@angular/core';
import { DashboardDataService } from 'src/app/services/dashboard-data.service';

@Component({
  selector: 'app-services',
  templateUrl: './services.component.html',
  styleUrls: ['./services.component.scss']
})
export class ServicesComponent implements OnInit {
  title="Świadczone usługi"

  constructor(private dashboardData: DashboardDataService ) { }

  ngOnInit(): void {
    this.dashboardData.setTitle(this.title)
  }

}
