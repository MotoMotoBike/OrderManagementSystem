import { bootstrapApplication } from '@angular/platform-browser';
import { ItemsComponent } from './app/items/items.component';
import { config } from './app/app.config.server';

const bootstrap = () => bootstrapApplication(ItemsComponent, config);

export default bootstrap;
