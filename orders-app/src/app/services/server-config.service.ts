// /src/app/services/server-config.service.ts
import { Inject, Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class ServerConfigService {
  constructor(
    @Inject('SERVER_ADDRESS') private serverAddress: string,
    @Inject('SERVER_PORT') private serverPort: number
  ) {}

  getServerUrl(): string {
    return `${this.serverAddress}:${this.serverPort}`;
  }
}
