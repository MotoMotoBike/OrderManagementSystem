import { Injectable } from '@angular/core';
import {CartItem} from './cart.item';

@Injectable({
  providedIn: 'root'
})
export class CartService {
  private cart: CartItem[] = [];

  addToCart(id: number, name: string, price: number): void {
    const existingItem = this.cart.find(item => item.id === id);
    if (existingItem) {
      existingItem.quantity += 1;
    } else {
      this.cart.push({ id, name, quantity: 1, price: price});
    }
  }

  getCartItems(): CartItem[] {
    return [...this.cart];
  }

  removeFromCart(id: number): void {
    const existingItem = this.cart.find(item => item.id === id);
    if (existingItem) {
      if (existingItem.quantity > 1) {
        existingItem.quantity -= 1;
      } else {
        this.cart = this.cart.filter(item => item.id !== id);
      }
    }
  }
  clearCart(): void {
    this.cart = [];
  }
}
