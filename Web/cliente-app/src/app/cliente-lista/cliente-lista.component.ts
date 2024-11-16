import { Component, OnInit } from '@angular/core';
import { ClienteService } from '../cliente.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-cliente-lista',
  templateUrl: './cliente-lista.component.html',
  styleUrls: ['./cliente-lista.component.scss']
})
export class ClienteListaComponent implements OnInit {

  clientes: Array<{ id: number, nomeEmpresa: string, porte: string }> = []; 

  constructor(
    private clienteService: ClienteService,
    private router: Router 
  ) {}

  ngOnInit(): void {
    console.log('ClienteListaComponent inicializado.');
    this.loadClientes();
  }

  loadClientes(): void {
    this.clienteService.getClientes().subscribe({
      next: (data: any) => {
        this.clientes = data;
      },
      error: (err) => {
        console.error('Erro ao carregar clientes:', err);
      }
    });
  }

  deleteCliente(id: number): void {
    if (confirm('Tem certeza de que deseja excluir este cliente?')) {
      this.clienteService.deleteCliente(id).subscribe({
        next: () => this.loadClientes(),
        error: (err) => console.error('Erro ao excluir cliente:', err)
      });
    }
  }

  navigateToEdit(clienteId: number): void {
    this.router.navigate(['/cliente/editar', clienteId]);
  }
}
