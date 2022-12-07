import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { MatSnackBar } from '@angular/material/snack-bar';
import { BehaviorSubject, Observable } from 'rxjs';
import { Loan } from 'src/app/Interfaces/loan';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class LoanService {

  private _loans: BehaviorSubject<Loan[]> = new BehaviorSubject<Loan[]>([]);

  public readonly loansList: Observable<Loan[]> = this._loans.asObservable();

  constructor(
    private http: HttpClient,
    private notification: MatSnackBar
  ) { 
    this.getLoansList();
  }

  saveNewLoan(loan: Loan): void {
    this.http.post<Loan>(`${environment.apiUrl}/Loan/Register`, loan).subscribe({
      complete: () => {
        this.notification.open('Prestamo registrado con exito!', "Aceptar", {verticalPosition: 'bottom'});
      }
    });
  }

  getLoansList(): void {
    this.http.get<Loan[]>(`${environment.apiUrl}/Loan/Loans`).subscribe(
      (data: Loan[]) => {
        this._loans.next(data);
      }
    );
  }

  getCurrentLoans(): void {
    this.http.get<Loan[]>(`${environment.apiUrl}/Loan/CurrentLoans`).subscribe(
      (data: Loan[]) => {
        this._loans.next(data);
      }
    );
  }

  getCLosedLoans(): void {
    this.http.get<Loan[]>(`${environment.apiUrl}/Loan/ClosedLoans`).subscribe(
      (data: Loan[]) => {
        this._loans.next(data);
      }
    );
  }

  setAsClosed(loan: Loan) : void {
    this.http.put<Loan>(`${environment.apiUrl}/Loan/Close`, loan).subscribe({
      complete: () => { 
        this.notification.open('Se registro la devolucion!', "Aceptar", {verticalPosition: 'bottom' });
      }
    });
  }
}
