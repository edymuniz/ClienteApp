import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../environments/environment';

@Injectable({
  providedIn: 'root'
})
export class ClienteService {

  //private apiUrl = `${environment.apiBaseUrl}/cliente`;
  private apiUrl = 'https://localhost:44388/Cliente';

  constructor(private http: HttpClient) { }

  getClientes(): Observable<any> {
    return this.http.get('https://localhost:44388/Cliente/all');
  }

  getClienteById(id: number): Observable<any> {
    return this.http.get(`${this.apiUrl}/${id}`);
  }

  createCliente(cliente: any): Observable<any> {
    return this.http.post(this.apiUrl, cliente);
  }

  updateCliente(id: number, cliente: any): Observable<any> {
    return this.http.put(`${this.apiUrl}/${id}`, cliente);
  }

  deleteCliente(id: number): Observable<any> {
    return this.http.delete(`${this.apiUrl}/${id}`);
  }
}
