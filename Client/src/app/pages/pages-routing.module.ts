import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Routes, RouterModule } from '@angular/router';
import { MainPageComponent } from './main-page/main-page.component';


const routes: Routes = [
  {
    path: '',
    component: MainPageComponent
  },
  { path: '**', redirectTo: 'login' }

]

@NgModule({
  declarations: [],
  imports: [
    CommonModule,
    RouterModule.forChild(routes)
  ]
})
export class PagesRoutingModule { }
