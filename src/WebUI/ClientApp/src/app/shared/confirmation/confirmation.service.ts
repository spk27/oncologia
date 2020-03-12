import { Injectable } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { ConfirmationComponent } from './confirmation.component';

@Injectable({
  providedIn: 'root'
})
export class ConfirmationService {

  constructor(public dialog: MatDialog) { }

  public desplegarError(error: any) {
    const dialogRef = this.dialog.open(ConfirmationComponent, {
        width: '550px',
        height: 'auto',
        data: {msj: error, type: "error"}
    });
  
    dialogRef.afterClosed().subscribe(result => {
        // console.log('El mensaje de error fue cerrado');
    });
  }

  public confirmCreation(msj: String) {
    const dialogRef = this.dialog.open(ConfirmationComponent, {
      width: '400px',
      height: 'auto',
      data: {msj: msj, type: "success"}
    });
  }
}
