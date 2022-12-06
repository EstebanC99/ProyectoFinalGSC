import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { MatSnackBar } from '@angular/material/snack-bar';
import { Loan } from 'src/app/Interfaces/loan';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class LoanService {

  constructor(
    private http: HttpClient,
    private notification: MatSnackBar
  ) { }

  saveNewLoan(loan: Loan): void {
    this.http.post<Loan>(`${environment.apiUrl}/Loan/Register`, loan).subscribe({
      complete: () => {
        this.notification.open('Prestamo registrado con exito!', "Aceptar", {verticalPosition: 'bottom'});
      }
    });
  }
}
