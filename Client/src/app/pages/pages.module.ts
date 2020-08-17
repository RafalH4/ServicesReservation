import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { PagesRoutingModule } from './pages-routing.module';
import { MainPageComponent } from './main-page/main-page.component';
import { HeaderComponent } from './header/header.component';
import { AvaiableServicesComponent } from './avaiable-services/avaiable-services.component';
import { SelectedServicesComponent } from './selected-services/selected-services.component';
import { ProvidersComponent } from './providers/providers.component';
import { ItemsComponent } from './items/items.component';



@NgModule({
  declarations: [
  MainPageComponent,
  HeaderComponent,
  AvaiableServicesComponent,
  SelectedServicesComponent,
  ProvidersComponent,
  ItemsComponent],
  imports: [
    CommonModule,
    PagesRoutingModule,
  ]
})
export class PagesModule { }
