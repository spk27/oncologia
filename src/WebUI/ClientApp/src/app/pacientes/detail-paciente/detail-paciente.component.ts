import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router, ParamMap } from '@angular/router';
import { PacientesService } from '../pacientes.service';
import { PacienteDetailVm } from 'src/app/oncologia-api';
import { switchMap } from 'rxjs/operators';
import { Observable } from 'rxjs';
import { faPersonBooth, faSignature, faIdCard, faLongArrowAltLeft } from '@fortawesome/free-solid-svg-icons';
import { error } from 'util';

@Component({
  selector: 'app-detail-paciente',
  templateUrl: './detail-paciente.component.html',
  styleUrls: ['./detail-paciente.component.css']
})
export class DetailPacienteComponent implements OnInit {
  icons = {
    faPersonBooth: faPersonBooth
    ,faSignature: faSignature
    ,faIdCard: faIdCard
    ,faLongArrowAltLeft: faLongArrowAltLeft
  }
  paciente$: Observable<PacienteDetailVm>;
  paciente: PacienteDetailVm;
  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private service: PacientesService
  ) { }

  ngOnInit() {
    this.route.paramMap.subscribe(pmap => this.getPaciente(pmap.get('id')),(error) => {
      console.error(JSON.stringify(error));
      this.resetPaciente();
    }
    ,() => console.log('finalizado'));
  }

  getPaciente(id: string) {
    if (!id) {
      this.resetPaciente();
      return;
    }

    this.service.getPaciente(parseInt(id)).subscribe(p => {
      if (p) {
        this.paciente = p;
      } else {
        this.resetPaciente();
      }
    },(error) => {
      // console.error(JSON.stringify(error));
      this.resetPaciente();
    }
    ,() => console.log('finalizado'));
  }

  goToPacientes(paciente: PacienteDetailVm) {
    let pacienteId = paciente ? paciente.id : null;
    this.router.navigate(['/pacientes', { id: pacienteId }]);
  }

  resetPaciente() {
    this.paciente = { 
      id: 0
      , primerNombre: ''
      , segundoNombre: ''
      , primerApellido: ''
      , segundoApellido: ''
      , cedula: ''
      , tipoCedula: '' } as PacienteDetailVm;
  }
}
