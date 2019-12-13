import { Component, OnInit } from '@angular/core';
import { PacientesClient, PacientesListVm } from '../oncologia-api';
import { PacientesService } from './pacientes.service';

@Component({
  selector: 'app-pacientes',
  templateUrl: './pacientes.component.html',
  styleUrls: ['./pacientes.component.css'],
  providers: [PacientesService]
})
export class PacientesComponent implements OnInit {

  private _client: PacientesClient;
  private pacientesVm: PacientesListVm = new PacientesListVm();
  public pacientesColumns: string[] = ['nombreCorto'];
  questions: any[];

  constructor(service: PacientesService) {
    // this.questions = service.upsertPacienteQuestion();
  }

  ngOnInit() {
  }

}
