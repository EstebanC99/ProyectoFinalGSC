import { NgModule, CUSTOM_ELEMENTS_SCHEMA } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { LoginComponent } from './login/login.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { AngularMaterialModule } from './angular-material.module';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { FlexLayoutModule } from '@angular/flex-layout';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { JwtInterceptor } from './jwt.interceptor';
import { ErrorInterceptor } from './error.interceptor';
import { AuthService } from './Services/Auth/auth.service';
import { MenuComponent } from './menu/menu.component';
import { PersonsDetailComponent } from './Persons/persons-detail/persons-detail.component';
import { PersonsListComponent } from './Persons/persons-list/persons-list.component';
import { PersonMenuComponent } from './Persons/person-menu/person-menu.component';
import { ConfirmCancelNotificationComponent } from './confirm-cancel-notification/confirm-cancel-notification.component';
import { MatDialogRef } from '@angular/material/dialog';
import { CategoriesListComponent } from './Categories/categories-list/categories-list.component';
import { CategoryDetailComponent } from './Categories/category-detail/category-detail.component';
import { CategoryMenuComponent } from './Categories/category-menu/category-menu.component';
import { NewLoanComponent } from './Loans/new-loan/new-loan.component';

@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
    MenuComponent,
    PersonsDetailComponent,
    PersonsListComponent,
    PersonMenuComponent,
    ConfirmCancelNotificationComponent,
    CategoriesListComponent,
    CategoryDetailComponent,
    CategoryMenuComponent,
    NewLoanComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    AngularMaterialModule,
    FormsModule,
    ReactiveFormsModule,
    FlexLayoutModule,
    HttpClientModule
  ],
  providers: [
    { provide: HTTP_INTERCEPTORS, useClass: JwtInterceptor, multi: true},
    { provide: HTTP_INTERCEPTORS, useClass: ErrorInterceptor, multi: true},
    { provide: MatDialogRef, useValue:{}},
    AuthService
  ],
  bootstrap: [AppComponent],
  schemas: [CUSTOM_ELEMENTS_SCHEMA]
})

export class AppModule { }