import { bootstrapApplication } from '@angular/platform-browser';
import {AppComponent} from './app/Items/items.component';

bootstrapApplication(AppComponent)
  .catch((err) => console.error(err));
