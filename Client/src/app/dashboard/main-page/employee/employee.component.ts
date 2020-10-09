import { Component, OnInit } from '@angular/core';
import { DashboardDataService } from 'src/app/services/dashboard-data.service';

@Component({
  selector: 'app-employee',
  templateUrl: './employee.component.html',
  styleUrls: ['./employee.component.scss']
})
export class EmployeeComponent implements OnInit {
  title="Pracownicy"

  constructor(private dashboardData: DashboardDataService ) { }

  ngOnInit(): void {
    this.dashboardData.setTitle(this.title)
  }

}
