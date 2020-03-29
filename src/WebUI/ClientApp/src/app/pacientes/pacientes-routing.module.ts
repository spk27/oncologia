import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { PacientesComponent } from './pacientes.component';
import { DetailPacienteComponent } from './detail-paciente/detail-paciente.component';

const routes: Routes = [
  { path: 'pacientes', component: PacientesComponent, data: { animation: 'pacientes' } },
  { path: 'paciente/:id', component: DetailPacienteComponent, data: { animation: 'paciente' } }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class PacientesRoutingModule { }
