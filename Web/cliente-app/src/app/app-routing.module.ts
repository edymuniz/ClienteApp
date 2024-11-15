import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { ClienteListaComponent } from './cliente-lista/cliente-lista.component'; 
import { ClienteFormComponent } from './cliente-form/cliente-form.component'; 

const routes: Routes = [
  { path: '', redirectTo: '/clientes', pathMatch: 'full' }, 
  { path: 'clientes', component: ClienteListaComponent }, 
  { path: 'cliente/criar', component: ClienteFormComponent }, 
  { path: 'cliente/editar/:id', component: ClienteFormComponent }, 
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
