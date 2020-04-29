import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { AuthModule } from './auth/auth.module';
import { AuthRoutingModule } from './auth/auth-routing.module';
import { CookieService} from 'ngx-cookie-service'
import { JwtHelperService, JwtModule, JWT_OPTIONS } from "@auth0/angular-jwt";
import { AuthService } from './auth/services/auth.service';
import { HttpHeaderInterceptor } from './auth/services/ReqInterceptor';
import { ErrorInterceptorProvider } from './auth/services/ErrorInterceptor';


export function jwtOptionsFactory(cookie: CookieService) {
  return {
    tokenGetter: () => {
      return cookie.get('token');
    }
  }
}

@NgModule({
  declarations: [
    AppComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    AuthModule,
    AuthRoutingModule,
    JwtModule.forRoot({
      jwtOptionsProvider: {
        provide: JWT_OPTIONS,
        useFactory: jwtOptionsFactory,
        deps: [CookieService]
      }
    })
  ],
  providers: [
    CookieService,
    AuthService,
    JwtHelperService,
    CookieService,
    HttpHeaderInterceptor,
    ErrorInterceptorProvider
  ],
  bootstrap: [AppComponent]
})
export class AppModule {}
