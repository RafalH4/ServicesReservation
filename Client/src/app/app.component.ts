import { Component } from '@angular/core';
import { AuthService } from './auth/services/auth.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {
  title = 'RestaurantClient';

  constructor( private authService: AuthService) {

  }

  logout(){
    this.authService.logout();
  }
}
