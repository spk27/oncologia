import { BrowserModule } from '@angular/platform-browser';
import { ReactiveFormsModule } from '@angular/forms';
import { NgModule, Injector } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { MaterialModule } from './materialUI/angularMaterialModule';
import { FontAwesomeModule } from '@fortawesome/angular-fontawesome';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { AppRoutingModule } from './routing/app-routing.module';
import { PacientesModule } from './pacientes/pacientes.module';

import { ConfirmationComponent } from './shared/confirmation/confirmation.component';
import { LoadingSpinnerComponent } from './shared/loading-spinner/loading-spinner.component';
import { LoadingSpinnerInterceptor } from './shared/loading-spinner/loading-spinner.interceptor';
import { ConfirmationService } from './shared/confirmation/confirmation.service';
import { PageNotFoundComponent } from './shared/page-not-found/page-not-found.component';

// export let InjectorInstance: Injector;
@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    ConfirmationComponent,
    LoadingSpinnerComponent,
    PageNotFoundComponent
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
    FontAwesomeModule,
    BrowserAnimationsModule,
    PacientesModule,
    AppRoutingModule,
  ],
  providers: [
    ConfirmationService
    ,{ provide: HTTP_INTERCEPTORS, useClass: LoadingSpinnerInterceptor, multi: true }
  ],
  bootstrap: [AppComponent]
})

export class AppModule {

  // constructor(private injector: Injector) 
  // {
  //   InjectorInstance = this.injector;
  // }
 }
