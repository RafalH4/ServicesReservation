import { AfterViewChecked, AfterViewInit, Component, OnInit} from '@angular/core';
import { AuthService } from 'src/app/auth/services/auth.service';
import { DashboardDataService } from 'src/app/services/dashboard-data.service';
import { ChangeDetectorRef } from '@angular/core'

@Component({
  selector: 'app-main-page',
  templateUrl: './main-page.component.html',
  styleUrls: ['./main-page.component.scss']
})
export class MainPageComponent implements OnInit, AfterViewInit {
  title="Grafik świadczonych usług"

  constructor(private authService: AuthService, private dashboardDataService: DashboardDataService, private cdr: ChangeDetectorRef) {

   }
  ngAfterViewInit(): void {
    this.dashboardDataService.getTitle().subscribe(data =>{
      this.title=data
    }) 
  }

  ngOnInit(): void {

  }
  
  ngAfterContentChecked() {
    this.cdr.detectChanges();
  }

  logout(){
    console.log("Wylogowuję")
    this.authService.logout();
  }

}
