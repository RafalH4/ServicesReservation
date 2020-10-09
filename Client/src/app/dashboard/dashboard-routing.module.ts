import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Routes, RouterModule } from '@angular/router';
import { MainPageComponent } from './main-page/main-page.component';
import { AdminPageComponent } from './admin-page/admin-page.component';
import { UsersComponent } from './admin-page/users/users.component';
import { EditUserComponent } from './admin-page/users/edit-user/edit-user.component';
import { AddUserComponent } from './admin-page/users/add-user/add-user.component';
import { AllUsersComponent } from './admin-page/users/all-users/all-users.component';
import { EditItemComponent } from './admin-page/items/edit-item/edit-item.component';
import { AddItemComponent } from './admin-page/items/add-item/add-item.component';
import { AllItemsComponent } from './admin-page/items/all-items/all-items.component';
import { ItemsComponent } from './admin-page/items/items.component';
import { DutyRosterComponent } from './main-page/duty-roster/duty-roster.component';
import { ServicesComponent } from './main-page/services/services.component';
import { EmployeeComponent } from './main-page/employee/employee.component';
import { ClientComponent } from './main-page/client/client.component';


const routes: Routes = [
  { path: '', component: MainPageComponent, 
  children: [
    {path: '', component: DutyRosterComponent},
    {path: 'duty-roster', component: DutyRosterComponent},
    {path: 'services', component: ServicesComponent},
    {path: 'employee', component: EmployeeComponent},
    {path: 'clients', component: ClientComponent}
  ] },
  { path: 'adminPage', component: AdminPageComponent },
  { path: 'users', component: UsersComponent,
    children: [
      { path: '', redirectTo: 'all', pathMatch: 'full' },
      { path: 'edit/:id', component: EditUserComponent },
      { path: 'new', component: AddUserComponent },
      { path: 'all', component: AllUsersComponent },
    ]
  },
  { path: 'items', component: ItemsComponent,
    children: [
      { path: '', redirectTo: 'all', pathMatch: 'full' },
      { path: 'edit/:id', component: EditItemComponent },
      { path: 'new', component: AddItemComponent },
      { path: 'all', component: AllItemsComponent },

    ]
  },
]
@NgModule({
  declarations: [],
  imports: [
    CommonModule,
    RouterModule.forChild(routes)
  ]
})
export class DashboardRoutingModule { }
