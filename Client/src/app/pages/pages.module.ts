import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { PagesRoutingModule } from './pages-routing.module';
import { MainPageComponent } from './main-page/main-page.component';
import { HeaderComponent } from './header/header.component';
import { AvaiableServicesComponent } from './avaiable-services/avaiable-services.component';
import { SelectedServicesComponent } from './selected-services/selected-services.component';



@NgModule({
  declarations: [
  MainPageComponent,
  HeaderComponent,
  AvaiableServicesComponent,
  SelectedServicesComponent],
  imports: [
    CommonModule,
    PagesRoutingModule,
  ]
})
export class PagesModule { }
