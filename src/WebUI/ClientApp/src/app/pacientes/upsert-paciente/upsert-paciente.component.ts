import { Component, OnInit, Output, EventEmitter } from '@angular/core';
import { PacientesClient, PacienteDto, UpsertPacienteCommand } from 'src/app/oncologia-api';
import { PacientesService } from '../pacientes.service';
import { FormGroup } from '@angular/forms';

@Component({
  selector: 'app-upsert-paciente',
  templateUrl: './upsert-paciente.component.html'
})
export class UpsertPacienteComponent implements OnInit {
  
  @Output() fromCreation = new EventEmitter<string>();
  // createForm: FormGroup;
  private paciente: UpsertPacienteCommand = new UpsertPacienteCommand();
  public submitted: boolean = false;

  constructor(private service: PacientesService) {
  }

  nuevoPaciente() {
    this.paciente = new UpsertPacienteCommand();
  }

  creandoNuevoPaciente() {
    this.service.createPaciente(this.paciente).then(r => {
      if(!r.error) {
        this.submitted = true;
        this.emitFromCreation(`El paciente ${this.paciente.primerNombre} ha sido creado`);
      } else this.emitFromCreation(`Ha ocurrido un problema al crear el paciente ${this.paciente.primerNombre} `);
      
    });
  }

  emitFromCreation(value: string) {
    console.log(value);
    this.fromCreation.emit(value);
  }

  ngOnInit() {
  }

}
