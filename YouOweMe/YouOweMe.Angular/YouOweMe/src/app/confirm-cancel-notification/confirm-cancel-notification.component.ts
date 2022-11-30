import { Component, Inject, OnInit } from '@angular/core';
import {MatDialog, MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';

@Component({
  selector: 'app-confirm-cancel-notification',
  templateUrl: './confirm-cancel-notification.component.html',
  styleUrls: ['./confirm-cancel-notification.component.css']
})
export class ConfirmCancelNotificationComponent implements OnInit {

  message: string = "¿Realmente desea realizar esta operacion?";
  confirmButtonText: string = "Aceptar";
  cancelButtonText: string = "Cancelar";

  constructor(@Inject(MAT_DIALOG_DATA) private data: any, private dialogRef: MatDialogRef<ConfirmCancelNotificationComponent>) { 
    if (data) {
      this.message = data.message || this.message;
      if (data.buttonText) {
        this.confirmButtonText = data.buttonText.ok || this.confirmButtonText;
        this.cancelButtonText = data.buttonText.cancel || this.cancelButtonText;
      }
    }
  }

  ngOnInit(): void {
  }

  onConfirmClick(): void {
    this.dialogRef.close(true);
  }

}
