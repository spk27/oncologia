import { Injectable } from '@angular/core';
import { PacientesClient, UpsertPacienteCommand, PacienteDto } from '../oncologia-api';
import { ConfirmationService } from '../shared/confirmation/confirmation.service';
import { Observable, Subject, BehaviorSubject } from 'rxjs';

@Injectable()
export class PacientesService {
    private _client: PacientesClient;
    pacienteCreadoData: BehaviorSubject<PacienteDto>;
    pacienteCreado: PacienteDto;
    //public error: any;

    constructor(client: PacientesClient, private confirmationService: ConfirmationService) {
        this._client = client;
        this.pacienteCreadoData = new BehaviorSubject(this.pacienteCreado);
    }
    
    public createPaciente(paciente: UpsertPacienteCommand) {
        return this._client.upsert(paciente).toPromise()
        .then(id => {
            this.pacienteCreadoExitoso(id, paciente);
            this.confirmationService.confirmCreation(`Paciente ${paciente.primerNombre} creado`);
            return {error: false, id}
        })
        .catch(errors => {
            this.confirmationService.desplegarError(errors);
            return {error: true, errors};
        });
    }

    pacienteCreadoExitoso(id: number, paciente: UpsertPacienteCommand) {
        this.pacienteCreado = new PacienteDto();
        this.pacienteCreado.id = id;
        this.pacienteCreado.nombreCorto = `${paciente.primerNombre} ${paciente.primerApellido[0]}.`
        this.pacienteCreadoData.next(this.pacienteCreado);
    }

    public deletePaciente(id: number) {
        return this._client.delete(id)
        .toPromise()
        .then(res => {
            return {error: false, res}
        })
        .catch(errors => {
            this.confirmationService.desplegarError(errors);
            return {error: true, errors};
        });
    }

    public getAllPacientes() {
        return this._client.getAll();
    }

    public sendConfirmation(msj: String) {
        this.confirmationService.desplegarError(msj);
    }
}