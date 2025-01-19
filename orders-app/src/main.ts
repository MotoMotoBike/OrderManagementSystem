import { bootstrapApplication } from '@angular/platform-browser';
import { provideRouter } from '@angular/router';
import { AppComponent } from './app/app.component';
import { routes } from './app/app.routes'; // Импортируем маршруты

bootstrapApplication(AppComponent, {
  providers: [
    provideRouter(routes) // Подключаем маршруты
  ]
}).catch(err => console.error(err));
