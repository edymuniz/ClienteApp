import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms'; 
import { ClienteFormComponent } from './cliente-form.component';

@NgModule({
  declarations: [ClienteFormComponent],
  imports: [
    CommonModule, 
    FormsModule   
  ],
  exports: [ClienteFormComponent] 
})
export class ClienteFormModule {}
