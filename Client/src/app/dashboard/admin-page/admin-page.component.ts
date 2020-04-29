import { Component, OnInit } from '@angular/core';
import { AuthService } from 'src/app/auth/services/auth.service';

@Component({
  selector: 'app-admin-page',
  templateUrl: './admin-page.component.html',
  styleUrls: ['./admin-page.component.scss']
})
export class AdminPageComponent implements OnInit {

  constructor(private authService: AuthService) { }

  ngOnInit(): void {
  }

  isAdmin():boolean{
    return this.authService.hasRole("admin");
  }

  isLogged():boolean{
    return this.authService.hasRole("admin") || this.authService.hasRole("client");
  }

}
