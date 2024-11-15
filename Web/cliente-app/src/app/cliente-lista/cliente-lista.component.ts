import { Component, OnInit } from '@angular/core';
import { ClienteService } from '../cliente.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-cliente-lista',
  templateUrl: './cliente-lista.component.html',
  styleUrls: ['./cliente-lista.component.scss']
})
export class ClienteListaComponent implements OnInit {

  clientes: any[] = [];

  constructor(
    private clienteService: ClienteService,
    private router: Router 
  ) { }

  ngOnInit(): void {
    this.loadClientes();
  }

  loadClientes(): void {
    this.clienteService.getClientes().subscribe((data: any) => {
      this.clientes = data;
    });
  }

  deleteCliente(id: number): void {
    this.clienteService.deleteCliente(id).subscribe(() => {
      this.loadClientes();
    });
  }

  navigateToEdit(clienteId: number): void {
    this.router.navigate(['/cliente/editar', clienteId]);
  }
}
