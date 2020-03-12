import { Component, OnInit, Output } from '@angular/core';
import { PacientesService } from '../pacientes.service';
import { PacientesListVm, PacienteDto } from 'src/app/oncologia-api';
import { MatTableDataSource } from '@angular/material/table';
import { error } from 'util';

@Component({
  selector: 'app-list-pacientes',
  templateUrl: './list-pacientes.component.html',
  styleUrls: ['./list-pacientes.component.css']
})
export class ListPacientesComponent implements OnInit {
  
  displayedColumns: string[] = ['id', 'nombreCorto', 'options'];
  private pacientesVM: PacientesListVm = new PacientesListVm();

  dataSource = new MatTableDataSource();
  
  constructor(private service: PacientesService) { }
  
  ngOnInit() {
    this.getAllPacientes();
    this.addPacientSubscription();
    
  }

  getAllPacientes() {
    this.service.getAllPacientes().subscribe(list => {
      this.pacientesVM = list;
      this.setPacientesListDataSource(list.pacientes);
    });
  }

  deletePaciente(id: number, index: number) {
    this.service.deletePaciente(id).then(r => {
      if(!r.error) {
        this.pacientesVM.pacientes.splice(index, 1);
        this.pacientesVM.count--;
        this.setPacientesListDataSource(this.pacientesVM.pacientes);
        this.service.sendConfirmation(`El paciente ha sido borrado`);
      }
    })
  }

  addPacientSubscription() {
    this.service.pacienteCreadoData.subscribe(paciente => {
      if(paciente) {
        this.pacientesVM.pacientes.push(paciente);
        this.pacientesVM.count++;
        this.setPacientesListDataSource(this.pacientesVM.pacientes);
      }
    })
  }

  setPacientesListDataSource(data: PacienteDto[]) {
    this.dataSource = new MatTableDataSource(data);
  }

}
