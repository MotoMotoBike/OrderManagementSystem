import { bootstrapApplication } from '@angular/platform-browser';
import {ItemsComponent} from './app/items/items.component';

bootstrapApplication(ItemsComponent)
  .catch((err) => console.error(err));
