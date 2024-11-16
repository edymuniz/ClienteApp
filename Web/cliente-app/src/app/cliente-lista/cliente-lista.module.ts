import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ClienteListaComponent } from './cliente-lista.component';

@NgModule({
  declarations: [ClienteListaComponent], 
  imports: [CommonModule],              
  exports: [ClienteListaComponent]      
})
export class ClienteListaModule {}
