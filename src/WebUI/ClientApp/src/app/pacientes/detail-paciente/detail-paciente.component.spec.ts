import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { HttpClientTestingModule } from '@angular/common/http/testing'
import { DetailPacienteComponent } from './detail-paciente.component';
import { FontAwesomeModule } from '@fortawesome/angular-fontawesome';
import { MaterialModule } from 'src/app/materialUI/angularMaterialModule';
import { RouterModule, ActivatedRoute, Router } from '@angular/router';
import { PacientesService } from '../pacientes.service';
import { PacientesClient, PacienteDetailVm, API_BASE_URL, PacienteDto } from 'src/app/oncologia-api';
import { HttpClient, HttpHandler } from '@angular/common/http';
import { ActivatedRouteStub } from 'testing/activated-route-stub';
// import { InjectorInstance } from 'src/app/app.module';
import { HttpClientModule } from "@angular/common/http";

let expectedPaciente: PacienteDetailVm = {"id":1000,"primerNombre":"Carlos", "segundoNombre": "Alfredo", "primerApellido":"Pedroza", "segundoApellido": "Loya", "cedula": "32423", "tipoCedula": "CC", "init":null, "toJSON":null};

let component: DetailPacienteComponent;
let fixture: ComponentFixture<DetailPacienteComponent>;
let page: Page;
let activatedRoute: ActivatedRouteStub;
// let _client: PacientesClient;
const routerSpy = jasmine.createSpyObj('Router', ['navigateByUrl']);
describe('DetailPacienteComponent', () => {

  beforeEach(async(() => {
    activatedRoute = new ActivatedRouteStub();

    TestBed.configureTestingModule({
      declarations: [ DetailPacienteComponent ]
      ,imports: [
        RouterModule
        ,FontAwesomeModule
        , MaterialModule
        ,HttpClientTestingModule
      ]
      ,providers: [
        PacientesClient
        ,{ provide: ActivatedRoute, useValue: activatedRoute }
        ,{provide: Router, useValue: routerSpy}
        ,PacientesService
        ,{ provide: API_BASE_URL, useValue: "http://localhost:5000" },
        
        // ,{provide: PacientesClient, useValue: _client}
      ]
    })
    .compileComponents()
    .then(createComponent);
  }));

  it('should display paciente data', () => {
    page.component.paciente = expectedPaciente;

    fixture.detectChanges();

    expect(page.pacienteDataDisplay[0].textContent).toBe(expectedPaciente.id.toString());
    expect(page.pacienteDataDisplay[1].textContent).toBe(`${expectedPaciente.primerNombre} ${expectedPaciente.segundoNombre}`);
    expect(page.pacienteDataDisplay[2].textContent).toBe(`${expectedPaciente.primerApellido} ${expectedPaciente.segundoApellido}`);
    expect(page.pacienteDataDisplay[3].textContent).toBe(`${expectedPaciente.tipoCedula} ${expectedPaciente.cedula}`);
  });

  // it('should create', () => {
  //   expect(component).toBeTruthy();
  // });
  
});

function createComponent() {
  activatedRoute.setParamMap({ id: 3 });
  
  fixture = TestBed.createComponent(DetailPacienteComponent);
  component = fixture.componentInstance;
  page = new Page(fixture);

  fixture.detectChanges();

  return fixture.whenStable().then(() => {
    fixture.detectChanges();
  });
}

class Page {
  // getter properties wait to query the DOM until called.
  get pacienteDataDisplay() { return this.queryAll<HTMLElement>('h3'); }

  goToPacientesSpy: jasmine.Spy;
  navigateSpy:  jasmine.Spy;
  _fixture: ComponentFixture<DetailPacienteComponent>;
  component: DetailPacienteComponent;
  constructor(fixture: ComponentFixture<DetailPacienteComponent>) {
    // get the navigate spy from the injected router spy object
    this._fixture = fixture;
    const routerSpy = <any> fixture.debugElement.injector.get(Router);
    this.navigateSpy = routerSpy.navigate;

    // spy on component's `goToPacientes()` method
    this.component = fixture.componentInstance;
    this.goToPacientesSpy = spyOn(this.component, 'goToPacientes').and.callThrough();
  }

  //// query helpers ////
  private query<T>(selector: string): T {
    return this._fixture.nativeElement.querySelector(selector);
  }

  private queryAll<T>(selector: string): T[] {
    return this._fixture.nativeElement.querySelectorAll(selector);
  }
}
