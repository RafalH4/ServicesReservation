import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Routes, RouterModule } from '@angular/router';
import { MainPageComponent } from './main-page/main-page.component';
import { AdminPageComponent } from './admin-page/admin-page.component';
import { UsersComponent } from './admin-page/users/users.component';
import { EditUserComponent } from './admin-page/users/edit-user/edit-user.component';
import { AddUserComponent } from './admin-page/users/add-user/add-user.component';


const routes: Routes = [
  {
    path: '',
    component: MainPageComponent
  },
  {
    path: 'adminPage',
    component: AdminPageComponent
  },
  {
    path: 'users',
    component: UsersComponent,
    children: [
      {
      path: 'edit',
      component: EditUserComponent
    },
    {
      path: 'new',
      component: AddUserComponent
    }
    ]
  }
]
@NgModule({
  declarations: [],
  imports: [
    CommonModule,
    RouterModule.forChild(routes)
  ]
})
export class DashboardRoutingModule { }
