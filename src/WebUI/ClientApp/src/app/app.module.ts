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
import { UpsertPacienteComponent } from './pacientes/upsert-paciente/upsert-paciente.component';
import { LoadingSpinnerComponent } from './shared/loading-spinner/loading-spinner.component';
import { LoadingSpinnerInterceptor } from './shared/loading-spinner/loading-spinner.interceptor';
import { PacientesService } from './pacientes/pacientes.service';
import { PacientesClient } from './oncologia-api';
import { ConfirmationService } from './shared/confirmation/confirmation.service';
import { ListPacientesComponent } from './pacientes/list-pacientes/list-pacientes.component';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    ConfirmationComponent,
    PacientesComponent,
    UpsertPacienteComponent,
    LoadingSpinnerComponent,
    ListPacientesComponent
  ],
  entryComponents: [
    ConfirmationComponent,
    LoadingSpinnerComponent
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
  providers: [
    PacientesService
    ,PacientesClient
    ,ConfirmationService
    ,{ provide: HTTP_INTERCEPTORS, useClass: LoadingSpinnerInterceptor, multi: true }
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
