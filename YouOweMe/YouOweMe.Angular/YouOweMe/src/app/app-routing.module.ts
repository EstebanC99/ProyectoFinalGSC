import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AuthGuard } from './auth.guard';
import { CategoryMenuComponent } from './Categories/category-menu/category-menu.component';
import { LoginComponent } from './login/login.component';
import { MenuComponent } from './menu/menu.component';
import { PersonMenuComponent } from './Persons/person-menu/person-menu.component';

const routes: Routes = [
  {path: '', pathMatch: 'full', redirectTo: 'Login'},
  {path: 'login', redirectTo: 'Login'},
  {path: 'Login', component: LoginComponent},
  {path: 'menu', redirectTo: 'Menu'},
  {path: 'Menu', component: MenuComponent, canActivate: [AuthGuard]},
  {path: 'Persons', component: PersonMenuComponent, canActivate: [AuthGuard]},
  {path: 'Categories', component: CategoryMenuComponent, canActivate: [AuthGuard]},
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})

export class AppRoutingModule { }