import { TestBed, inject } from '@angular/core/testing';
import { PacientesService } from './pacientes.service'
import { PacientesClient, API_BASE_URL, PacienteDto } from '../oncologia-api';
import { ConfirmationService } from '../shared/confirmation/confirmation.service';
import { HttpClientTestingModule, HttpTestingController } from '@angular/common/http/testing';
import { MaterialModule } from 'src/app/materialUI/angularMaterialModule';
import { HttpClient, HttpResponse } from '@angular/common/http';

describe('PacientesService', () => {
    const expectedPacientes: PacienteDto[] = [{"id":3,"nombreCorto":"Dani A.", "init":null, "toJSON":null}];
    let service: PacientesService;
    let _client: PacientesClient;
    let pacientesClientSpy: { getAll: jasmine.Spy };
    let confirmationSpy:ConfirmationService;
    let httpClient: HttpClient;
    let httpTestingController: HttpTestingController;

    beforeEach(() => {
        pacientesClientSpy = jasmine.createSpyObj('PacientesClient', ['getAll']);
        service = new PacientesService(<any> pacientesClientSpy, confirmationSpy);
        let spy = jasmine.createSpyObj('PacientesClient', ['getAll']);
        TestBed.configureTestingModule({
            imports: [
                HttpClientTestingModule
                ,MaterialModule
            ]
            ,providers: [
                PacientesService
                ,PacientesClient
                //,{provide: PacientesClient, useValue: spy}
                ,ConfirmationService
                ,{ provide: API_BASE_URL, useValue: "http://localhost:5000" }
            ]
        })
        //service = TestBed.get(PacientesService);
        //pacientesClientSpy = TestBed.get(PacientesClient);
    });

    beforeEach(inject([PacientesService
        ,PacientesClient
        ,HttpClient
        ,HttpTestingController]
        ,(serv, client, http, httptest) => {
        service = serv;
        _client = client;
        httpClient = http;
        httpTestingController = httptest;
    }));

    it('should be created', () => {
        expect(service).toBeTruthy();
    });


    it('should retrieve pacientes list 1', () => {
        service.getAllPacientes().subscribe(
            pacientes => {
                //expect(pacientes.length).toBeGreaterThan(0);
                expect(pacientes).toEqual(expectedPacientes);
            },
            error => {
                fail('Se esperaba una lista de pacientes: ' + error)
            }
        )
        const req = httpTestingController.expectOne('http://localhost:5000/api/Pacientes/GetAll');
        
        expect(req.request.method).toEqual('GET');

        // req.event(new HttpResponse<PacienteDto[]>({body: expectedPacientes, headers:  }));
        
        //req.flush({body: expectedPacientes });

        httpTestingController.verify();
        
    });

    it('should retrieve pacientes list', () => {
        
        httpClient.get<PacienteDto[]>('http://localhost:5000/api/Pacientes/GetAll')
            .subscribe(data =>
            // When observable resolves, result should match test data
                expect(data).toEqual(expectedPacientes)
            );

        const req = httpTestingController.expectOne('http://localhost:5000/api/Pacientes/GetAll');

        expect(req.request.method).toEqual('GET');

        req.flush(expectedPacientes);

        httpTestingController.verify();
    });

    // afterEach(() => {
    //     // After every test, assert that there are no more pending requests.
    //     httpTestingController.verify();
    // });
});
