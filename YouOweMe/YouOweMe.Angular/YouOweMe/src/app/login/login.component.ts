import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { first } from 'rxjs';
import { AuthService } from '../auth.service';
import { User } from '../user';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})

export class LoginComponent implements OnInit {

  public loginForm!: FormGroup;
  submitted: boolean = false;
  error: string = "";

  constructor(private formBuilder: FormBuilder, 
              private router: Router,
              private authService: AuthService) {
    if (this.authService.currentUserValue){
      this.router.navigate(['/Menu']);
    }
  }

  ngOnInit(): void {
    this.loginForm = this.formBuilder.group({
      email: ["", [Validators.email, Validators.required]],
      password: ["", [Validators.required, Validators.minLength(5), Validators.maxLength(10)]]
    });
  }

  get formControl(){
    return this.loginForm.controls;
  }

  getEmailError(): string {
    let email: string = this.formControl['email'].value;

    if (email == "" || email == null)
      return "El Email es requerido";
    else
      return "Ingrese un Email valido";
  }

  getPasswordError(): string {
    let password: string =  this.formControl['password'].value;

    if (password == "" || password == null)
      return "Debe ingresar una password";
    
    if (password.length < 5)
      return "Su password debe tener mas de 5 caracteres";

    if (password.length > 10)
      return "Su password debe tener menos de 10 caracteres";
    
    return "Algo no esta bien";
  }

  login(): void {
    if (this.loginForm.invalid)
      return;

    this.submitted = true;

    let user: User = {
      email: this.formControl['email'].value,
      password: this.formControl['password'].value
    }

    this.authService.login(user)
      .pipe(first())
      .subscribe({
        error: (e) => this.error = e,
        complete: () => this.router.navigate(['/Menu']),
      });
  }
}