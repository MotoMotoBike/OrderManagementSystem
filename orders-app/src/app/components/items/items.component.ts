import { HttpClientModule } from '@angular/common/http';
import { Component } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import {FormsModule} from '@angular/forms';
import {CommonModule} from '@angular/common';
import {Router, RouterOutlet} from '@angular/router';
import {environment} from '../../../environments/environment.development';
import {CartService} from '../../services/cart.service';

@Component({
  selector: 'items',
  standalone: true,
  imports: [HttpClientModule, FormsModule, CommonModule, RouterOutlet],
  templateUrl: './items.component.html',
})

export class ItemsComponent {

  serverUrl: string = environment.apiBaseUrl;
  Items: Item[] = [];

  newItemName = "";
  newItemPrice = 0;
  constructor(private http: HttpClient,
              private router: Router,
              private cartService: CartService) {
  }

  getItemsList() {
    this.http.get(this.serverUrl + '/Items/GetItems')
      .subscribe((response) => {
        this.Items = response as Item[];
      });
  }
  ngOnInit(): void {
    this.getItemsList();
  }

  addItem() {

    this.http.post(this.serverUrl + '/Items/CreateItem',
      {
        itemName: this.newItemName,
        price: this.newItemPrice
      })
      .subscribe(
        (response) => {
          console.log(response);
          this.getItemsList();
          alert('Item added successfully!');
        },
          (error) => {
            alert('The item was not added. Please check the parameters and try again.');
        });
  }

  removeItem(id: number) {
    const url = `${this.serverUrl}/Items/DeleteItem?id=${id}`;

    this.http.delete(url)
      .subscribe({
        next: (response) => {
          console.log('Item deleted successfully:', response);
          this.getItemsList();
        },
        error: (err) => {
          console.error('Error occurred while deleting item:', err);
        }
      });
  }

  addToCart(item: Item): void {
    console.log('Adding item to cart:', item);
    this.cartService.addToCart(item.id, item.productName, item.unitPrice);
  }

  validateNumberInput(event: KeyboardEvent): void {
    const inputValue = (event.target as HTMLInputElement).value + event.key;

    if (event.key === '-' || event.key === '+') {
      event.preventDefault();
      return;
    }

    if (inputValue.startsWith('0') && inputValue[1] !== '.' && inputValue.length > 1) {
      event.preventDefault();
      return;
    }

    const decimalIndex = inputValue.indexOf('.');
    if (decimalIndex !== -1 && inputValue.substring(decimalIndex + 1).length > 2) {
      event.preventDefault();
    }
    if (inputValue.length > 15) {
      event.preventDefault();
    }
  }

  validateTextInput(event: KeyboardEvent): void {
    const inputValue = (event.target as HTMLInputElement).value + event.key;
    if (inputValue.length > 20) {
      event.preventDefault();
    }
  }

  handleFocus(event: FocusEvent): void {
    const inputElement = event.target as HTMLInputElement;
    inputElement.value = '';
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
