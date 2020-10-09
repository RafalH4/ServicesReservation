import { AfterViewChecked, AfterViewInit, Component, OnChanges, OnInit, SimpleChanges } from '@angular/core';
import { AuthService } from 'src/app/auth/services/auth.service';
import { DashboardDataService } from 'src/app/services/dashboard-data.service';

@Component({
  selector: 'app-main-page',
  templateUrl: './main-page.component.html',
  styleUrls: ['./main-page.component.scss']
})
export class MainPageComponent implements OnInit, AfterViewInit {
  title="Treść"

  constructor(private authService: AuthService, private dashboardDataService: DashboardDataService) {

   }
  ngAfterViewInit(): void {
    this.dashboardDataService.getTitle().subscribe(data =>{
      this.title=data
    })
  }

  ngOnInit(): void {

  }

  logout(){
    console.log("Wylogowuję")
    this.authService.logout();
  }

}
