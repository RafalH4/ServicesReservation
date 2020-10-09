import { Component, OnInit } from '@angular/core';
import { DashboardDataService } from 'src/app/services/dashboard-data.service';

@Component({
  selector: 'app-duty-roster',
  templateUrl: './duty-roster.component.html',
  styleUrls: ['./duty-roster.component.scss']
})
export class DutyRosterComponent implements OnInit {
  title="Grafik świadczonych usług"

  constructor(private dashboardData: DashboardDataService) { }

  ngOnInit(): void {
    this.dashboardData.setTitle(this.title)
  }

}
