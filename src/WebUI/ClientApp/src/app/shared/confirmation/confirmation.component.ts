import { Component, OnInit, Inject, EventEmitter } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';

export interface Message {
  msj: string,
  type: string
}

@Component({
  selector: 'app-confirmation',
  templateUrl: './confirmation.component.html',
  styleUrls: ['./confirmation.component.css']
})

export class ConfirmationComponent implements OnInit {
  public errors: any;
  public onConfirm = new EventEmitter();

  constructor(public dialogRef: MatDialogRef<ConfirmationComponent>, 
    @Inject(MAT_DIALOG_DATA) public data: Message) {
      if(data.type === 'error') this.errors = data.msj;
     }

  confirm() {
    this.onConfirm.emit();
    this.onNoClick();
  }

  onNoClick(): void {
    this.dialogRef.close();
  }

  ngOnInit() {
  }

  get manageError() {
    if(Array.isArray(this.errors)) {
      let errores = [];
       Object.keys(this.errors).map(e => {
        return "hola";
      });
      return ['das','asdas'];
    } else return this.errors;
  }

  get isArray() {
    return typeof this.errors === 'object' || false;
  }

  get errorKeys() {
    return Object.keys(this.errors);
  }

}