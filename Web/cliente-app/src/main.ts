import { bootstrapApplication } from '@angular/platform-browser';
import { provideHttpClient } from '@angular/common/http';  // Importando a função para fornecer o HttpClient
import { appConfig } from './app/app.config';  // Seu arquivo de configuração
import { AppComponent } from './app/app.component';

bootstrapApplication(AppComponent, {
  providers: [
    provideHttpClient(),  // Certifique-se de que o HttpClient é fornecido
    ...appConfig.providers // Aqui você adiciona outros providers definidos em appConfig
  ]
})
  .catch((err) => console.error(err));
