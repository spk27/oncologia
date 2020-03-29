import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { HttpClientTestingModule } from '@angular/common/http/testing'
import { UpsertPacienteComponent } from './upsert-paciente.component';
import { FontAwesomeModule } from '@fortawesome/angular-fontawesome';
import { MaterialModule } from 'src/app/materialUI/angularMaterialModule';
import { PacientesService } from '../pacientes.service';
import { PacienteDto, UpsertPacienteCommand } from 'src/app/oncologia-api';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { By } from '@angular/platform-browser';
import { of } from 'rxjs';
import { click } from 'src/testing';

let newPaciente: UpsertPacienteCommand =
  {"id":1000,"primerNombre":"Carlos", "segundoNombre": "Alfredo", "primerApellido":"Pedroza", "segundoApellido": "Loya", "cedula": "32423", "tipoCedula": "CC", "init":null, "toJSON":null};
let fixture: ComponentFixture<UpsertPacienteComponent>;
let component: UpsertPacienteComponent;
let page: Page;
const pacienteServiceSpy = jasmine.createSpyObj('PacientesService', ['createPaciente']);
const getCreationSpy = pacienteServiceSpy.createPaciente.and.returnValue( of({error: false, id: newPaciente.id}) );

describe('UpsertPacienteComponent', () => {

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ UpsertPacienteComponent ]
      ,imports: [
        FormsModule
        ,BrowserAnimationsModule
        ,FontAwesomeModule
        , MaterialModule
        ,HttpClientTestingModule
      ]
      ,providers: [
        { provide: PacientesService, useValue: pacienteServiceSpy}
      ]
    })
    .compileComponents()
    .then(createComponent);
  }));

  it('should create', () => {
    expect(component).toBeTruthy();
  });

  it('should emit event when create new paciente', () => {
      let msj: string;
      component.paciente = newPaciente;

      component.fromCreation.subscribe(p => {
        msj = p;
      });
      
      click(page.enviarFormDe);
      
      expect(getCreationSpy.calls.any()).toBe(true, 'creación de servicio llamado');

      component.emitFromCreation(`El paciente ${newPaciente.primerNombre} ha sido creado`);

      expect(msj).toMatch(`El paciente ${newPaciente.primerNombre} ha sido creado`, 'paciente creado exitosamente');
  })
  
});

function createComponent() {
    fixture = TestBed.createComponent(UpsertPacienteComponent);
    component = fixture.componentInstance;
    page = new Page();

    fixture.detectChanges();

    return fixture.whenStable().then(() => {
      fixture.detectChanges();
    });
  }

class Page {

  enviarFormDe = fixture.debugElement.query(By.css('.enviarNuevoPaciente'));
  // enviarEL = this.pacienteDe.nativeElement; para usar enviarEL.click()

  constructor() {
  }

  //// query helpers ////
  private query<T>(selector: string): T {
    return fixture.nativeElement.querySelector(selector);
  }

  private queryAll<T>(selector: string): T[] {
    return fixture.nativeElement.querySelectorAll(selector);
  }
}
