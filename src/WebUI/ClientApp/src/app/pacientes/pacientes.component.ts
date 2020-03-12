import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-pacientes',
  templateUrl: './pacientes.component.html',
  styleUrls: ['./pacientes.component.css']
})
export class PacientesComponent implements OnInit {
  
  msj: String = "";

  constructor() {
  }

  asignarAviso(msj: String) {
    console.log(msj);
    this.msj = msj;
  }

  clearAviso() {
    this.msj = "";
  }

  ngOnInit() {
  }

}
