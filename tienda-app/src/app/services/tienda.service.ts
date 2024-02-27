import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from '../../environments/environment';

@Injectable({
  providedIn: 'root',
})
export class TiendaService {
  constructor(private readonly _clienteHttp: HttpClient) {}

  public obtener(): Observable<string[]> {
    return this._clienteHttp.get<string[]>(`${environment.apiUrl}/tienda`);
  }
}
