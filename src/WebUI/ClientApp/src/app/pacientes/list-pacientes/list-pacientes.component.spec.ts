import { async, ComponentFixture, TestBed, inject, fakeAsync, tick } from '@angular/core/testing';

import { ListPacientesComponent } from './list-pacientes.component';
import { MaterialModule } from 'src/app/materialUI/angularMaterialModule';
import { RouterModule, ActivatedRoute, Router } from '@angular/router';
import { FontAwesomeModule } from '@fortawesome/angular-fontawesome';
import { PacientesService } from '../pacientes.service';
import { PacientesClient, API_BASE_URL, PacienteDto, UpsertPacienteCommand } from 'src/app/oncologia-api';
import { HttpClientModule } from '@angular/common/http';
import { HttpClientTestingModule, HttpTestingController } from '@angular/common/http/testing';
import { Observable, BehaviorSubject } from 'rxjs';
import { ActivatedRouteStub } from 'testing/activated-route-stub';
import { resolve } from 'dns';
import { click } from 'testing';
import { By } from '@angular/platform-browser';
import { RouterLinkDirectiveStub } from 'testing/router-link-directive-stub';

let component: ListPacientesComponent;
let fixture: ComponentFixture<ListPacientesComponent>;
let pacienteService : PacientesService;
let activatedRoute: ActivatedRouteStub;
const routerSpy = jasmine.createSpyObj('Router', ['navigateByUrl']);
const pacienteServiceSpy = jasmine.createSpyObj('PacientesService', ['getAllPacientes','pacienteCreadoExitoso']);
let page: Page;

let expectedPaciente: PacienteDto = {"id":3,"nombreCorto":"Dani A.", "init":null, "toJSON":null};
let expectedPacientes: PacienteDto[] = [
  expectedPaciente
];
let newPacienteDto: PacienteDto = 
  {"id":1000,"nombreCorto":"Carlos P.", "init":null, "toJSON":null};
let newPaciente: UpsertPacienteCommand =
  {"id":1000,"primerNombre":"Carlos", "segundoNombre": "Alfredo", "primerApellido":"Pedroza", "segundoApellido": "Loya", "cedula": "32423", "tipoCedula": "CC", "init":null, "toJSON":null};

describe('ListPacientesComponent', () => {
  activatedRoute = new ActivatedRouteStub();

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ListPacientesComponent, RouterLinkDirectiveStub ]
      , imports: [
        RouterModule
        ,HttpClientTestingModule
        ,MaterialModule
        ,FontAwesomeModule
      ]
      , providers: [
        { provide: ActivatedRoute, useValue: activatedRoute }
        ,{provide: PacientesService, useClass: MockPacienteService}
        ,{provide: Router, useValue: routerSpy}
        ,{ provide: API_BASE_URL, useValue: "http://localhost:5000" },
      ]
    })
    .compileComponents()
    .then(createComponent);

    
  }));
  
  it('should create', () => {
    expect(component).toBeTruthy();
  });

  
  it('should pacientes$ be Observable', () => {
    expect(component.pacientes$).toBeDefined();
  });

  it('should pacientes$ contain observable object', () => {
    component.pacientes$.subscribe(p => {
      expect(p.length).toBeGreaterThan(0);
      expect(p).toEqual(expectedPacientes);
    });
  });

  it('shold test pacientes table', () => {
    expect(page.pacientesRow.length).toBeGreaterThan(0);

    let headerRow = page.pacientesRow[0];
    expect(headerRow.cells[0].innerHTML).toBe('No.');
    expect(headerRow.cells[1].innerHTML).toBe('Nombre');
    expect(headerRow.cells[2].innerHTML).toBe('Opciones');
    
    headerRow = page.pacientesRow[1];
    expect(headerRow.cells[0].innerHTML).toBe(expectedPacientes[0].id.toString());
    expect(headerRow.cells[1].innerHTML).toBe(expectedPacientes[0].nombreCorto);
  });

  it('should add and delete paciente to list', fakeAsync(() => {
    expectedPacientes.push(newPacienteDto);
    pacienteService.pacienteCreadoExitoso(newPaciente.id, newPaciente);
    
    tick(2000);
    fixture.detectChanges();  

    expect(page.pacientesRow.length).toBeGreaterThan(2);
    
    let nombreCorto = `${newPaciente.primerNombre} ${newPaciente.primerApellido[0]}.`;
    let headerRow = page.pacientesRow[2]; // 2 de nuevo paciente
    expect(headerRow.cells[0].innerHTML).toBe(newPaciente.id.toString());
    expect(headerRow.cells[1].innerHTML).toBe(nombreCorto); 
           
    if(expectedPacientes.length == 2) {
      expectedPacientes.splice(1, 1);
      component.deletePaciente(newPaciente.id, 1);
      tick(2000);
      fixture.detectChanges();   
      expect(page.pacientesRow.length).toEqual(2);
    } else {
      expectedPacientes.splice(0, 1);
      component.deletePaciente(expectedPaciente.id, 1);
      tick(2000);
      fixture.detectChanges();   
      expect(page.pacientesRow.length).toEqual(1);
    }
  }));

  /* NO SE PUEDE TESTEAR ROUTERLINK PORQUE SE ENCUENTRA DENTRO DEL MAT-TABLE Y NO LO ENCUENTRA
  it('can get RouterLinks from template', () => {
    // find DebugElements with an attached RouterLinkStubDirective
    let linkDes = fixture.debugElement
    .queryAll(By.directive(RouterLinkDirectiveStub));

    // get attached link directive instances
    // using each DebugElement's injector
    let routerLinks = linkDes.map(de => de.injector.get(RouterLinkDirectiveStub));

    expect(routerLinks.length).toBe(1, 'debe linkear el primer y unico paciente de la lista');
    expect(routerLinks[0].linkParams).toBe('/paciente/3', 'url del primer paciente');
  });

  it('should tell router to navigate when paciente is clicked', () => {
    click(page.goToPacienteBtn[0]);
    // click(fixture.debugElement.query(By.css('.goToPacienteBtn')).nativeElement);

    const navArgs = page.navSpy.calls.first().args[0];

    expect(navArgs).toBe(`/paciente/${expectedPaciente.id}`, 'debe navegar al primer paciente de la lista');
  })
  */
});

function createComponent() {
  fixture = TestBed.createComponent(ListPacientesComponent);
  component = fixture.componentInstance;
  pacienteService = fixture.debugElement.injector.get(PacientesService);
  //pacienteService = TestBed.get(PacientesService);

  fixture.detectChanges();

  return fixture.whenStable().then(() => {
    fixture.detectChanges();
    page = new Page();
  });
}

class Page {

  get pacientesRow() { return fixture.nativeElement.querySelectorAll('tr'); }
  get goToPacienteBtn() { return fixture.nativeElement.querySelectorAll('button');}

  navSpy: jasmine.Spy;

  constructor() {

    // Get the component's injected router navigation spy
    const routerSpy = fixture.debugElement.injector.get(Router);
    this.navSpy = routerSpy.navigateByUrl as jasmine.Spy;
  };
}

class MockPacienteService {
  pacienteCreado: PacienteDto;
  pacienteCreadoData: BehaviorSubject<PacienteDto> = new BehaviorSubject(this.pacienteCreado);

  getAllPacientes() : Observable<PacienteDto[]> { 

    return new Observable((observer) => {
      observer.next(expectedPacientes);
    });
  }

  pacienteCreadoExitoso(id: number, paciente: UpsertPacienteCommand) {
    this.pacienteCreado = new PacienteDto();
    this.pacienteCreado.id = id;
    this.pacienteCreado.nombreCorto = `${paciente.primerNombre} ${paciente.primerApellido[0]}.`;
    this.pacienteCreadoData.next(this.pacienteCreado);
  }

  deletePaciente(id: number) {
    return Promise.resolve({error: false, res: 'Paciente borrado'});
  }

  sendConfirmation(msj: String) {
    console.log(`El paciente ha sido borrado`);
    
  }
};