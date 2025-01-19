import { Injectable } from '@angular/core';
import {CartItem} from './cart.item';

@Injectable({
  providedIn: 'root'
})
export class CartService {
  private cart: CartItem[] = [];

  // Добавить товар в корзину
  addToCart(id: number, name: string, price: number): void {
    const existingItem = this.cart.find(item => item.id === id);
    if (existingItem) {
      // Если товар уже в корзине, увеличиваем количество
      existingItem.quantity += 1;
    } else {
      // Если товара нет, добавляем новый
      this.cart.push({ id, name, quantity: 1, price: price});
    }
  }

  // Получить все товары из корзины
  getCartItems(): CartItem[] {
    return [...this.cart]; // Возвращаем копию массива, чтобы избежать мутаций
  }

  // Удалить товар из корзины
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
  // Очистить корзину
  clearCart(): void {
    this.cart = [];
  }
}
