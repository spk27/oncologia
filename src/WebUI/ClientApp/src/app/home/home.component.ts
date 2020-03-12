import { Component } from '@angular/core';
import { MatDialog, MatDialogRef } from '@angular/material/dialog';
import { ConfirmationComponent } from '../shared/confirmation/confirmation.component';
import { LoadingSpinnerService } from '../shared/loading-spinner/loading-spinner.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent {

  constructor(public dialog: MatDialog, private loadingSpinnerService: LoadingSpinnerService) {}

  openConfirmation() {
    const dialogRef = this.dialog.open(ConfirmationComponent, {
      width: '250px',
      data: {msj: "mensajee", type: "error"}
    });

    dialogRef.afterClosed().subscribe(result => {
      console.log('The dialog was closed');
    });
  }

  openLoading() {
    this.loadingSpinnerService.startLoading();
  }

  closeLoading() {
    this.loadingSpinnerService.stopLoading();
  }
}
