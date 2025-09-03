import { Component, OnInit } from '@angular/core';
import { NgIf, NgFor } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { ProdutosService } from '../services/produtos.service';
import { Produto } from '../models/produto';

@Component({
  selector: 'app-produtos',
  standalone: true,                     // <-- standalone
  imports: [NgIf, NgFor, FormsModule],  // <-- diretivas + forms
  templateUrl: './produtos.component.html'
})
export class ProdutosComponent implements OnInit {
  produtos: Produto[] = [];
  novo = { nome: '', preco: 0 };
  loading = false;
  error = '';

  constructor(private svc: ProdutosService) {}

  ngOnInit(): void { this.load(); }

  load() {
    this.loading = true;
    this.svc.listar().subscribe({
      next: (dados) => { this.produtos = dados; this.loading = false; },
      error: () => { this.error = 'Falha ao listar'; this.loading = false; }
    });
  }

  criar() {
    if (!this.novo.nome || this.novo.preco <= 0) return;
    this.svc.criar(this.novo).subscribe({
      next: () => { this.novo = { nome: '', preco: 0 }; this.load(); },
      error: () => { this.error = 'Falha ao criar'; }
    });
  }

  excluir(id: number) {
    this.svc.excluir(id).subscribe({
      next: () => this.load(),
      error: () => { this.error = 'Falha ao excluir'; }
    });
  }
}
