import { bootstrapApplication } from '@angular/platform-browser';
import {ItemsComponent} from './app/Items/items.component';

bootstrapApplication(ItemsComponent)
  .catch((err) => console.error(err));
