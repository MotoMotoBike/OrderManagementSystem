import { HttpClientModule } from '@angular/common/http';
import { Component } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import {FormsModule} from '@angular/forms';
import {CommonModule} from '@angular/common';
import {Router, RouterOutlet} from '@angular/router';
import {environment} from '../environment';

@Component({
  selector: 'cart-root',
  imports: [HttpClientModule, FormsModule, CommonModule, RouterOutlet],
  templateUrl: './cart.component.html',
  standalone : true
})

export class CartComponent {

  serverUrl: string = environment.apiBaseUrl;
  Cart: Item[] = [];

  newItemName = "";
  newItemPrice = 0;
  constructor(private http: HttpClient,
              private router: Router) {
  }

  getCartList() {
    this.http.get(this.serverUrl + 'Cart/GetCart')
      .subscribe((response) => {
        this.Cart = response as Item[];
      });
  }
  ngOnInit(): void {
    this.getCartList();
  }


  addItem() {

    this.http.post(this.serverUrl + 'Cart/CreateItem',
      {
        itemName: this.newItemName,
        price: this.newItemPrice
      })
      .subscribe((response) => {
        console.log(response);
        this.getCartList();
      });
  }

  removeItem(id: number) {
    const url = `${this.serverUrl}Cart/DeleteItem?id=${id}`;

    this.http.delete(url)
      .subscribe({
        next: (response) => {
          console.log('Item deleted successfully:', response);
          this.getCartList();
        },
        error: (err) => {
          console.error('Error occurred while deleting item:', err);
        }
      });
  }
}

export interface Item {
  id: number
  createdAt: string
  modifiedAt: string
  isDeleted: boolean
  productName: string
  unitPrice: number
}
