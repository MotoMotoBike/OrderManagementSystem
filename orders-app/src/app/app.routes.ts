import { Routes } from '@angular/router';
import {ItemsComponent} from './items/items.component';
import {CartComponent} from './cart/cart.component';

export const routes: Routes = [
  { path : '', redirectTo: 'items', pathMatch: 'full' },
  { path : 'items', component: ItemsComponent },
  { path : 'cart', component: CartComponent },
];
