import { Component, OnInit, Inject, EventEmitter } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';

export interface Message {
  msj: string,
  type: string
}

@Component({
  selector: 'app-confirmation',
  templateUrl: './confirmation.component.html'
})

export class ConfirmationComponent implements OnInit {
  public error: any;
  public onConfirm = new EventEmitter();

  constructor(public dialogRef: MatDialogRef<ConfirmationComponent>, 
    @Inject(MAT_DIALOG_DATA) public data: Message) { }

  confirm() {
    this.onConfirm.emit();
    this.onNoClick();
  }

  onNoClick(): void {
    this.dialogRef.close();
  }

  ngOnInit() {
  }

}