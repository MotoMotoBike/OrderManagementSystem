import { mergeApplicationConfig, ApplicationConfig } from '@angular/core';
import { provideServerRendering } from '@angular/platform-server';
import { provideServerRoutesConfig } from '@angular/ssr';
import { appConfig } from './app.config';
import { serverRoutes } from './app.routes.server';

const serverConfig: ApplicationConfig = {
  providers: [
    provideServerRendering(),
    provideServerRoutesConfig(serverRoutes),
    {
      provide: 'SERVER_ADDRESS',
      useValue: 'http://localhost',  // Ваш адрес сервера
    },
    {
      provide: 'SERVER_PORT',
      useValue: 5091,  // Порт сервера
    }
  ],
};

export const config = mergeApplicationConfig(appConfig, serverConfig);
