import { Routes } from '@angular/router';

import {ItemsComponent} from './components/items/items.component';
import {CartComponent} from './components/cart/cart.component';
import {HomeComponent} from './components/home/home.component';
import {OrdersComponent} from './components/orders/orders.component';

export const routes: Routes = [
  { path: '', component: HomeComponent, },
  { path: 'items', component: ItemsComponent, },
  { path: 'cart', component: CartComponent, },
  { path: 'orders', component: OrdersComponent, },
];
