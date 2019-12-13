import { Component, OnInit } from '@angular/core';
import { PacientesClient } from 'src/app/oncologia-api';
import { PacientesService } from '../pacientes.service';


@Component({
  selector: 'app-upsert-paciente',
  templateUrl: './upsert-paciente.component.html',
  providers: [PacientesService]
})
export class UpsertPacienteComponent implements OnInit {

  private _client: PacientesClient;
  questions: any[];

  constructor(service: PacientesService) {
    this.questions = service.upsertPacienteQuestion();
  }

  ngOnInit() {
  }

}
