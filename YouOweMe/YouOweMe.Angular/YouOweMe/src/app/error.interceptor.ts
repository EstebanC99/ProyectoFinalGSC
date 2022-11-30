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
import { NestedTreeControl } from '@angular/cdk/tree';

@Injectable()
export class ErrorInterceptor implements HttpInterceptor {

  constructor(
    private authService: AuthService,
    private notification: MatSnackBar) {}

  intercept(request: HttpRequest<unknown>, next: HttpHandler): Observable<HttpEvent<any>> {
    let notificationMessage = "";

    return next.handle(request).pipe(catchError(err => {
      switch (err.status){
        case HTTPResponses.Unathorized:
          this.authService.logout();
          location.reload();
          notificationMessage = err.error;
          break;
        case HTTPResponses.InternalServerError:
          notificationMessage = err.error;
          break;
        default: 
          notificationMessage = "Ocurrio un error, reintente mas tarde";
          break;
      }

      this.showNotification(notificationMessage);
      return throwError(() => err);
    }));
  }

  showNotification(message: string): void {
    this.notification.open(message, "Cerrar", {verticalPosition: "bottom"});
  }
}