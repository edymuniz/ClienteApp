import { ApplicationConfig } from '@angular/core';
import { provideRouter } from '@angular/router';
import { provideHttpClient } from '@angular/common/http';
import { importProvidersFrom } from '@angular/core';
import { CommonModule } from '@angular/common'; 
import { HttpClientModule } from '@angular/common/http';
import { ClienteListaModule } from './cliente-lista/cliente-lista.module';
import { ClienteFormModule } from './cliente-form/cliente-form.module';
import { routes } from './app.routes';

export const appConfig: ApplicationConfig = {
  providers: [
    provideRouter(routes),
    provideHttpClient(),
    importProvidersFrom(CommonModule, HttpClientModule, ClienteListaModule, ClienteFormModule) 
  ]
};