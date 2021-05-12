import { UserUpdateComponent } from './user-update/user-update.component';

import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { UserCreateComponent } from './user-create/user-create.component';
import { UserListComponent } from './user-list/user-list.component';


const routes: Routes = [
  { path: 'User-List', component: UserListComponent },
  { path: 'User-Create', component: UserCreateComponent },
  { path: 'update/:id', component: UserUpdateComponent },


];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
