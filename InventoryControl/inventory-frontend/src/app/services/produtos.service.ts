import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Produto } from '../models/produto';

@Injectable({ providedIn: 'root' })
export class ProdutosService {
  private base = '/api/produtos'; // <-- simples e direto

  constructor(private http: HttpClient) {}

  listar(): Observable<Produto[]> {
    return this.http.get<Produto[]>(this.base);
  }

  criar(data: Omit<Produto, 'id'>): Observable<Produto> {
    return this.http.post<Produto>(this.base, data);
  }

  excluir(id: number): Observable<void> {
    return this.http.delete<void>(`${this.base}/${id}`);
  }
}
