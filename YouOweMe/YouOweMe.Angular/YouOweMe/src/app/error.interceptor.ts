import { Injectable } from '@angular/core';
import {
  HttpRequest,
  HttpHandler,
  HttpEvent,
  HttpInterceptor
} from '@angular/common/http';
import { catchError, Observable, throwError } from 'rxjs';
import { AuthService } from './Services/Auth/auth.service';
import { HTTPResponses } from './httpresponses';
import { MatSnackBar } from '@angular/material/snack-bar';

@Injectable()
export class ErrorInterceptor implements HttpInterceptor {

  constructor(
    private authService: AuthService,
    private notification: MatSnackBar) {}

  intercept(request: HttpRequest<unknown>, next: HttpHandler): Observable<HttpEvent<any>> {
    return next.handle(request).pipe(catchError(err => {
      if (err.status == HTTPResponses.Unathorized) {
        this.authService.logout();
        location.reload();
      }

      const error = err.error || err.statusText;
      this.showNotification(error);
      return throwError(() => error);
    }));
  }

  showNotification(message: string): void {
    this.notification.open(message, "Cerrar", {verticalPosition: "bottom"});
  }
}