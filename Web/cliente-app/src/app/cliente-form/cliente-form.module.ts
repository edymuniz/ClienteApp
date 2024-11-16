import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ClienteFormComponent } from './cliente-form.component';

@NgModule({
  declarations: [ClienteFormComponent], 
  imports: [CommonModule],              
  exports: [ClienteFormComponent]      
})
export class ClienteFormModule {}