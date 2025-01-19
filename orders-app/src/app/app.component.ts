import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';

@Component({
  selector: 'app-root',
  standalone: true, // Это standalone-компонент
  imports: [RouterOutlet], // Подключаем маршрутизацию через RouterOutlet
  templateUrl: './app.component.html'
})
export class AppComponent {}
