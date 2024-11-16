import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../environments/environment';

@Injectable({
  providedIn: 'root'
})
export class ClienteService {

  private apiUrl = `${environment.apiBaseUrl}/Cliente`;

  constructor(private http: HttpClient) { }

  getClientes(): Observable<any> {
    return this.http.get('http://localhost:5272/api/Cliente/all');
  }

  getClienteById(id: number): Observable<any> {
    return this.http.get(`${this.apiUrl}/${id}`);
  }

  createCliente(cliente: { nomeEmpresa: string; porte: string }): Observable<any> {
    return this.http.post<any>('http://localhost:5272/api/Cliente', cliente);
  }

  // createCliente(cliente: any): Observable<any> {
  //   return this.http.post('http://localhost:5272/api/Cliente', cliente);
  // }

  updateCliente(id: number, cliente: any): Observable<any> {
    return this.http.put(`${this.apiUrl}/${id}`, cliente);
  }

  deleteCliente(id: number): Observable<any> {
    return this.http.delete(`${this.apiUrl}/${id}`);
  }
}
