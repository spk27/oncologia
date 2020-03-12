import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ListPacientesComponent } from './list-pacientes.component';

describe('ListPacientesComponent', () => {
  let component: ListPacientesComponent;
  let fixture: ComponentFixture<ListPacientesComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ListPacientesComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ListPacientesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
