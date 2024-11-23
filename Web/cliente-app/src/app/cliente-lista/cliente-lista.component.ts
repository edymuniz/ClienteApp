import { Component, OnInit } from '@angular/core';
import { ClienteService } from '../cliente.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-cliente-lista',
  templateUrl: './cliente-lista.component.html',
  styleUrls: ['./cliente-lista.component.scss']
})
export class ClienteListaComponent implements OnInit {

  clientes: Array<{ id: number, nomeEmpresa: string, porte: string }> = []; // Mantém o tipo para exibir na tela

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
      next: (response: any) => {
        if (response.success && response.data) {
          this.clientes = response.data; // Extrai os clientes diretamente da propriedade "data"
        } else {
          console.warn('Nenhum cliente encontrado ou resposta inválida.');
        }
      },
      error: (err) => {
        console.error('Erro ao carregar clientes:', err);
      }
    });
  }

  deleteCliente(id: number): void {
    if (confirm('Tem certeza de que deseja excluir este cliente?')) {
      this.clienteService.deleteCliente(id).subscribe({
        next: () => {
          console.log(`Cliente com ID ${id} excluído com sucesso.`);
          this.loadClientes();
        },
        error: (err) => console.error('Erro ao excluir cliente:', err)
      });
    }
  }

  navigateToEdit(clienteId: number): void {
    this.router.navigate(['/cliente/editar', clienteId]);
  }
}
