import { HttpClientModule } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import {CartItem} from '../../services/cart.item';
import {CartService} from '../../services/cart.service';
import {CommonModule} from '@angular/common';
import {environment} from '../../../environments/environment.development';
import {HttpClient} from '@angular/common/http';
@Component({
  selector: 'app-cart',
  templateUrl: './cart.component.html',
  imports: [HttpClientModule,CommonModule],
})
export class CartComponent implements OnInit {
  cartItems: CartItem[] = [];

  serverUrl: string = environment.apiBaseUrl;
  constructor(
    private http: HttpClient,
    private cartService: CartService) {}

  ngOnInit(): void {
    this.loadCart();
  }

  loadCart(): void {
    console.log('Adding item to cart:', this.cartService.getCartItems());
    this.cartItems = this.cartService.getCartItems();
  }

  increaseQuantity(item: CartItem): void {
    this.cartService.addToCart(item.id, item.name, item.price);
    this.loadCart();
  }

  decreaseQuantity(item: CartItem): void {
    this.cartService.removeFromCart(item.id);
    this.loadCart();
  }
  calculateTotalPrice(): number {
    return this.cartItems.reduce((total, item) => total + item.price * item.quantity, 0);
  }

  mapCartToOrderDto(cartItems: CartItem[]): OrderItemDto[] {
    return cartItems.map(item => ({
      itemId: item.id,
      quantity: item.quantity
    }));
  }


  checkout(): void {
    if (this.cartItems.length === 0) {
      alert("Your cart is empty. Please add items before proceeding to checkout.");
    } else {

      let orderDto: OrderItemDto[] = this.mapCartToOrderDto(this.cartItems);

      this.http.post(this.serverUrl + '/Orders/CreateOrder',
        { itemIds: orderDto})
        .subscribe((response) => {
          alert("Order placed! Thank you for your purchase.");
        }, (error) => {
          alert("The order was not placed due to a system error.");
        });

      this.clearCart();
    }
  }

  clearCart(): void {
    this.cartService.clearCart();
    this.loadCart();
  }
}
export interface OrderItemDto {
  itemId: number;
  quantity: number;
}

export interface CreateOrderDto {
  itemIds: OrderItemDto[];
}
