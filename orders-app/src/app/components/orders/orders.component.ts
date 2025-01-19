import { Component, OnInit } from '@angular/core';
import {HttpClient, HttpClientModule} from '@angular/common/http';
import { environment } from '../../../environments/environment.development';
import {CommonModule} from '@angular/common';


export interface Item {
  id: number
  createdAt: string
  modifiedAt: string
  isDeleted: boolean
  productName: string
  unitPrice: number
}
interface OrderItemDto {
  id: number;
  quantity: number;
  itemId: number;
  createdAt: string;
  modifiedAt: string;
  isDeleted: boolean;
  orderId: number;
  item: Item;
}

interface OrderDto {
  id: number;
  createdAt: string;
  modifiedAt: string;
  isDeleted: boolean;
  orderName: string;
  orderItem: OrderItemDto[];
  totalPrice: number;
}

@Component({
  selector: 'app-orders',
  templateUrl: './orders.component.html',
  imports: [HttpClientModule, CommonModule],
})
export class OrdersComponent implements OnInit {

  orders: OrderDto[] = [];
  serverUrl = environment.apiBaseUrl;

  constructor(private http: HttpClient) { }

  ngOnInit(): void {
    this.getOrders();
  }

  // Метод для запроса всех заказов
  getOrders(): void {
    this.http.get<OrderDto[]>(`${this.serverUrl}Orders/GetOrders`)
      .subscribe((response) => {
        this.orders = response;
        console.log(this.orders); // Для дебага
      });
  }
  deleteOrder(id : number): void {
    this.http.delete(`${this.serverUrl}Orders/DeleteOrder?id=${id}`)
      .subscribe(() => {
        this.orders = this.orders.filter((o) => o.id !== id);
      });
  }
}
