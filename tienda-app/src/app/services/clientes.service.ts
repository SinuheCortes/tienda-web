import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from '../../environments/environment';
import { Cliente } from '../interfaces/cliente.interface';

@Injectable({
  providedIn: 'root',
})
export class ClienteService {
  constructor(private readonly _clienteHttp: HttpClient) {}

  public obtener(): Observable<Cliente[]> {
    return this._clienteHttp.get<Cliente[]>(`${environment.apiUrl}/clientes`);
  }

  public obtenerUnico(id: string): Observable<Cliente> {
    return this._clienteHttp.get<Cliente>(
      `${environment.apiUrl}/clientes/${id}`
    );
  }

  public guardar(cliente: Cliente): Observable<boolean> {
    return this._clienteHttp.post<boolean>(
      `${environment.apiUrl}/clientes`,
      cliente
    );
  }

  public actualizar(cliente: Cliente, id: string): Observable<boolean> {
    return this._clienteHttp.put<boolean>(
      `${environment.apiUrl}/clientes/${id}`,
      cliente
    );
  }

  public eliminar(id: string): Observable<boolean> {
    return this._clienteHttp.delete<boolean>(
      `${environment.apiUrl}/clientes/${id}`
    );
  }
}
