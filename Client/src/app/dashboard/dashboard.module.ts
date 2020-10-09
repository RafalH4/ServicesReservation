import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { ReactiveFormsModule } from '@angular/forms';
import { DashboardRoutingModule } from './dashboard-routing.module';
import { MainPageComponent } from './main-page/main-page.component';
import { UserPageComponent } from './user-page/user-page.component';
import { AdminPageComponent } from './admin-page/admin-page.component';
import { UsersComponent } from './admin-page/users/users.component';
import { EditUserComponent } from './admin-page/users/edit-user/edit-user.component';
import { AddUserComponent } from './admin-page/users/add-user/add-user.component';
import { AllUsersComponent } from './admin-page/users/all-users/all-users.component';
import { ItemsComponent } from './admin-page/items/items.component';
import { AddItemComponent } from './admin-page/items/add-item/add-item.component';
import { AllItemsComponent } from './admin-page/items/all-items/all-items.component';
import { EditItemComponent } from './admin-page/items/edit-item/edit-item.component';
import { DutyRosterComponent } from './main-page/duty-roster/duty-roster.component';
import { ServicesComponent } from './main-page/services/services.component';
import { EmployeeComponent } from './main-page/employee/employee.component';
import { ClientComponent } from './main-page/client/client.component';




@NgModule({
  declarations: [MainPageComponent, UserPageComponent, AdminPageComponent, UsersComponent, EditUserComponent, AddUserComponent, AllUsersComponent, ItemsComponent, AddItemComponent, AllItemsComponent, EditItemComponent, DutyRosterComponent, ServicesComponent, EmployeeComponent, ClientComponent],
  imports: [
    CommonModule,
    DashboardRoutingModule,
    RouterModule,
    ReactiveFormsModule
  ]
})
export class DashboardModule { }
