import { Injectable } from '@angular/core';
import { Subject } from "rxjs";
import { LoadingSpinnerComponent } from './loading-spinner.component';
import { MatDialogRef, MatDialog } from '@angular/material/dialog';

@Injectable({
  providedIn: 'root'
})
export class LoadingSpinnerService {

  private _loading: boolean = false;
  loadingStatus: Subject<boolean> = new Subject();
  private dialogRef : MatDialogRef<LoadingSpinnerComponent>;

  constructor(public dialog: MatDialog) {}
  get loading():boolean {
    return this._loading;
  }

  set loading(value) {
    this._loading = value;
  }

  startLoading() {
    this.loading = true;
    this.dialogRef = this.dialog.open(LoadingSpinnerComponent, {
      // hasBackdrop : false,
      panelClass: 'spinner',
      disableClose: true,
      
    });

    this.dialogRef.afterClosed().subscribe(result => {
      console.log('The dialog was closed');
    });
  }

  stopLoading() {
    this.loading = false;
    if(this.dialogRef) this.dialogRef.close();
  }
}
