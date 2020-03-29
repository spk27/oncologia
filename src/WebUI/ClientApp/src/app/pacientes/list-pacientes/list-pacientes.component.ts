import { Component, OnInit, Output } from '@angular/core';
import { PacientesService } from '../pacientes.service';
import { 
  // PacientesListVm
  PacienteDto } from 'src/app/oncologia-api';
import { MatTableDataSource } from '@angular/material/table';
import { faIdCardAlt } from '@fortawesome/free-solid-svg-icons';
// import { ActivatedRoute } from '@angular/router';
import { switchMap } from 'rxjs/operators';
import { Observable, observable } from 'rxjs';

@Component({
  selector: 'app-list-pacientes',
  templateUrl: './list-pacientes.component.html',
  styleUrls: ['./list-pacientes.component.css']
})
export class ListPacientesComponent implements OnInit {
  icons = {
    faIdCardAlt: faIdCardAlt
  }
  displayedColumns: string[] = ['id', 'nombreCorto', 'options'];
  public pacientes$: Observable<PacienteDto[]>;

  selectedId: number;

  constructor(
    private service: PacientesService,
    //private route: ActivatedRoute
    ) { }
  
  ngOnInit() {    
    this.getAllPacientes();
    this.addPacientSubscription();    
  }

  getAllPacientes() {
    /* este metodo para rutas activas
    this.pacientes$ = this.route.paramMap.pipe(
      switchMap(params => {
       this.selectedId = parseInt(params.get('id'));
       return this.service.getAllPacientes();
      })
    );

    this.pacientes$.subscribe(list => {
      this.pacientesVM = list;
      this.setPacientesListDataSource(list.pacientes);
    });
    */

    /* observable simple
    this.service.getAllPacientes().subscribe(list => {
      this.pacientesVM = list;
      this.setPacientesListDataSource(list.pacientes);
    });
    */

    this.updatePacientesObservable();
  }

  deletePaciente(id: number, index: number) {
    this.service.deletePaciente(id).then(r => {
      if(!r.error) {
        this.updatePacientesObservable();
        this.service.sendConfirmation(`El paciente ha sido borrado`);
      }
    })
  }

  addPacientSubscription() {
    this.service.pacienteCreadoData.subscribe(paciente => {
      this.updatePacientesObservable();
    })
  }

  updatePacientesObservable() {
    this.pacientes$ = this.service.getAllPacientes();
  }

}
