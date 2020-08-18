import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { DashboardRoutingModule } from './dashboard-routing.module';
import { MainPageComponent } from './main-page/main-page.component';
import { UserPageComponent } from './user-page/user-page.component';
import { AdminPageComponent } from './admin-page/admin-page.component';
import { UsersComponent } from './admin-page/users/users.component';
import { EditUserComponent } from './admin-page/users/edit-user/edit-user.component';
import { AddUserComponent } from './admin-page/users/add-user/add-user.component';
import { AllUsersComponent } from './admin-page/users/all-users/all-users.component';




@NgModule({
  declarations: [MainPageComponent, UserPageComponent, AdminPageComponent, UsersComponent, EditUserComponent, AddUserComponent, AllUsersComponent],
  imports: [
    CommonModule,
    DashboardRoutingModule,
    RouterModule
  ]
})
export class DashboardModule { }
