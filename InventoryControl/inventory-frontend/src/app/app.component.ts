import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet],
  template: `
    <nav style="margin-bottom:1rem">
      <a routerLink="/produtos">Produtos</a>
    </nav>
    <router-outlet></router-outlet>
  `
})
export class AppComponent {}
