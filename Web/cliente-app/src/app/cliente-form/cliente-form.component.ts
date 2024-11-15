import { Component } from '@angular/core';
import { ClienteService } from '../cliente.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-cliente-form',
  templateUrl: './cliente-form.component.html',
  styleUrls: ['./cliente-form.component.scss']
})
export class ClienteFormComponent {
  
  nomeEmpresa: string = '';
  porte: string = '';
  errorMessage: string = '';

  constructor(
    private clienteService: ClienteService,
    private router: Router
  ) { }

  
  isFormValid(): boolean {
    return this.nomeEmpresa.length >= 3 && this.porte.length >= 2;
  }

  
  saveCliente(): void {
    if (this.isFormValid()) {
      const cliente = this.createCliente();

      this.clienteService.createCliente(cliente).subscribe({
        next: () => this.router.navigate(['/clientes']),
        error: () => this.handleError('Erro ao salvar o cliente.')
      });
    } else {
      this.handleError('Todos os campos são obrigatórios e devem ter o tamanho mínimo.');
    }
  }


  private createCliente() {
    return {
      nomeEmpresa: this.nomeEmpresa,
      porte: this.porte
    };
  }

  
  private handleError(message: string): void {
    this.errorMessage = message;
  }

 
  onNomeEmpresaChange(event: Event): void {
    const input = event.target as HTMLInputElement;
    this.nomeEmpresa = input.value;
  }

  onPorteChange(event: Event): void {
    const input = event.target as HTMLInputElement;
    this.porte = input.value;
  }
}
