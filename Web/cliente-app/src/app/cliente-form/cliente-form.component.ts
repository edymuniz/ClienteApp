import { Component, OnInit } from '@angular/core';
import { ClienteService } from '../cliente.service';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-cliente-form',
  templateUrl: './cliente-form.component.html',
  styleUrls: ['./cliente-form.component.scss']
})
export class ClienteFormComponent implements OnInit {

  nomeEmpresa: string = '';
  porte: string = '';
  errorMessage: string = '';
  isEditMode: boolean = false; // Identifica se estamos no modo de edição
  clienteId: number | null = null;

  constructor(
    private clienteService: ClienteService,
    private route: ActivatedRoute,
    private router: Router
  ) { }

  ngOnInit(): void {
    this.route.paramMap.subscribe(params => {
      const id = params.get('id');
      console.log('ID capturado na rota:', id); // Debug
      if (id) {
        this.isEditMode = true;
        this.clienteId = parseInt(id, 10);
        console.log('Modo edição ativado. Cliente ID:', this.clienteId); // Debug
        this.loadCliente(this.clienteId);
      } else {
        console.log('Modo criação ativado.'); // Debug
      }
    });
  }
  

  private loadCliente(id: number): void {
    this.clienteService.getClienteById(id).subscribe({
      next: (cliente) => {
        this.nomeEmpresa = cliente.nomeEmpresa;
        this.porte = cliente.porte;
      },
      error: (err) => {
        console.error('Erro ao carregar o cliente:', err);
        this.handleError('Não foi possível carregar os dados do cliente.');
      }
    });
  }

  saveCliente(): void {
    if (this.isEditMode && this.clienteId) {
      this.updateCliente();
    } else {
      this.createCliente();
    }
  }

  private createCliente(): void {
    const cliente = this.createClienteObject();
    this.clienteService.createCliente(cliente).subscribe({
      next: () => {
        console.log('Cliente criado com sucesso!');
        this.router.navigate(['/clientes']);
      },
      error: (err) => {
        console.error('Erro ao salvar o cliente:', err);
        this.handleError('Erro ao salvar o cliente.');
      }
    });
  }

  private updateCliente(): void {
    const cliente = this.createClienteObject();
    this.clienteService.updateCliente(this.clienteId!, cliente).subscribe({
      next: () => {
        console.log('Cliente atualizado com sucesso!');
        this.router.navigate(['/clientes']);
      },
      error: (err) => {
        console.error('Erro ao atualizar o cliente:', err);
        this.handleError('Erro ao atualizar o cliente.');
      }
    });
  }

  private createClienteObject(): any {
    return {
      nomeEmpresa: this.nomeEmpresa,
      porte: this.porte
    };
  }

  private handleError(message: string): void {
    this.errorMessage = message;
  }
}
