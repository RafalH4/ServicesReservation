import { Component, OnInit } from '@angular/core';
import { DashboardDataService } from 'src/app/services/dashboard-data.service';

@Component({
  selector: 'app-client',
  templateUrl: './client.component.html',
  styleUrls: ['./client.component.scss']
})
export class ClientComponent implements OnInit {
  title="Klienci"

  constructor(private dashboardData: DashboardDataService ) { }

  ngOnInit(): void {
    this.dashboardData.setTitle(this.title)
  }

}
