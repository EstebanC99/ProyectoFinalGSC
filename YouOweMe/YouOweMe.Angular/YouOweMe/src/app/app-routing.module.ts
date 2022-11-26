import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AuthGuard } from './auth.guard';
import { LoginComponent } from './login/login.component';
import { MenuComponent } from './menu/menu.component';
import { PersonMenuComponent } from './person-menu/person-menu.component';
import { PersonsListComponent } from './persons-list/persons-list.component';

const routes: Routes = [
  {path: '', pathMatch: 'full', redirectTo: 'Login'},
  {path: 'login', redirectTo: 'Login'},
  {path: 'Login', component: LoginComponent},
  {path: 'menu', redirectTo: 'Menu'},
  {path: 'Menu', component: MenuComponent, canActivate: [AuthGuard]},
  {path: 'Persons', component: PersonMenuComponent, canActivate: [AuthGuard]}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})

export class AppRoutingModule { }