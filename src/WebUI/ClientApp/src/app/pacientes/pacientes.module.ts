import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { PacientesRoutingModule } from './pacientes-routing.module';
import { MaterialModule } from '../materialUI/angularMaterialModule';
import { ReactiveFormsModule, FormsModule } from '@angular/forms';
import { FontAwesomeModule } from '@fortawesome/angular-fontawesome';

import { PacientesComponent } from './pacientes.component';
import { PacientesClient } from '../oncologia-api';
import { PacientesService } from './pacientes.service';
import { UpsertPacienteComponent } from './upsert-paciente/upsert-paciente.component';
import { ListPacientesComponent } from './list-pacientes/list-pacientes.component';
import { DetailPacienteComponent } from './detail-paciente/detail-paciente.component';

@NgModule({
  declarations: [
    PacientesComponent
    ,UpsertPacienteComponent
    ,ListPacientesComponent
    ,DetailPacienteComponent
  ],
  imports: [
    CommonModule
    ,ReactiveFormsModule
    ,FormsModule
    ,PacientesRoutingModule
    ,MaterialModule
    ,FontAwesomeModule
  ],
  providers: [
    PacientesService
    ,PacientesClient
  ]
})
export class PacientesModule { }
