import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ClienteListaComponent } from './cliente-lista/cliente-lista.component'; // Seu componente de lista de clientes
import { ClienteFormComponent } from './cliente-form/cliente-form.component'; // Seu componente de formulário de cliente

export const routes: Routes = [
  { path: 'clientes', component: ClienteListaComponent },
  { path: 'cliente/editar/:id', component: ClienteFormComponent },
  { path: 'cliente/criar', component: ClienteFormComponent },
  { path: '', redirectTo: '/clientes', pathMatch: 'full' }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
