import { BrowserModule } from '@angular/platform-browser';
import { ReactiveFormsModule }          from '@angular/forms';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MaterialModule } from './angularMaterialModule';
import { PacientesComponent } from './pacientes/pacientes.component';
import { ConfirmationComponent } from './shared/confirmation/confirmation.component';
import { DynamicFormComponent } from './shared/dynamic-forms/dynamic-form.component';
import { DynamicFormQuestionComponent } from './shared/dynamic-forms/dynamic-form-question.component';
import { UpsertPacienteComponent } from './pacientes/upsert-paciente/upsert-paciente.component';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    ConfirmationComponent,
    DynamicFormComponent,
    DynamicFormQuestionComponent,
    PacientesComponent,
    UpsertPacienteComponent
  ],
  entryComponents: [
    ConfirmationComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    ReactiveFormsModule,
    HttpClientModule,
    FormsModule,
    MaterialModule,
    RouterModule.forRoot([
      { path: '', component: HomeComponent, pathMatch: 'full' },
      { path: 'pacientes', component: PacientesComponent },
    ]),
    BrowserAnimationsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
