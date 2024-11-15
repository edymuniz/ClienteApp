import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { ClienteListaComponent } from './cliente-lista/cliente-lista.component';
import { ClienteFormComponent } from './cliente-form/cliente-form.component';
import { FormsModule } from '@angular/forms';
import { ClienteService } from './cliente.service';


@NgModule({
  declarations: [
    AppComponent,
    ClienteListaComponent,
    ClienteFormComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    AppRoutingModule,
    FormsModule
  ],
  providers: [ClienteService],
  bootstrap: [AppComponent]
})
export class AppModule { }
