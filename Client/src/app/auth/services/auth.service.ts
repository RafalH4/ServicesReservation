import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { FormGroup } from '@angular/forms';
import { Observable } from 'rxjs';
import { User } from 'src/app/models/user.model';
import { map } from 'rxjs/operators';
import { CookieService } from 'ngx-cookie-service';
import { JwtHelperService } from '@auth0/angular-jwt';
import { Router } from '@angular/router';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  baseUrl: string = 'https://localhost:44300/User'
  public currentUser: Observable<User>


  constructor(private http: HttpClient,
    private cookieService: CookieService,
    private jwtHelper: JwtHelperService,
    private router: Router) { }

  login(model: FormGroup) {
    return this.http.post(this.baseUrl + '/login', model)
      .pipe(
        map((response: any) => {
          this.cookieService.set('token', response.token);
        })
      )
  }

  logout() {
    if (!this.cookieService.get('token')) {
      alert("Nie jesteś zalogowany")
      return 0;
    }
    this.cookieService.delete('token');
    alert("Wylogowano poprawnie")
    this.router.navigate(['']);
  }

  registerClient(model: FormGroup) {
    return this.http.post(this.baseUrl + '/registerClient', model)
  }
  registerAdmin(model: FormGroup) {
    return this.http.post(this.baseUrl + '/registerAdmin', model)
  }

  getToken() {
    return this.cookieService.get('token');
  }

  loggedIn() {
    const token = this.cookieService.get('token');
    return !this.jwtHelper.isTokenExpired(token);
  }

  hasRole(role: string) {
    const token = this.jwtHelper.decodeToken(this.getToken())
    if(token)
      return token.role === role;
      else
      return false
  }




}

