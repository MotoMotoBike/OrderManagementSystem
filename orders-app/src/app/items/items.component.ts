import { HttpClientModule } from '@angular/common/http';
import { Component } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import {FormsModule} from '@angular/forms';
import {CommonModule} from '@angular/common';
import {Router, RouterOutlet} from '@angular/router';
import {environment} from '../environment';

@Component({
  selector: 'items-root',
  imports: [HttpClientModule, FormsModule, CommonModule, RouterOutlet],
  templateUrl: './items.component.html'
})

export class ItemsComponent {

  serverUrl: string = environment.apiBaseUrl;
  Items: Item[] = [];

  newItemName = "";
  newItemPrice = 0;
  constructor(private http: HttpClient,
              private router: Router) {
  }

  getItemsList() {
    this.http.get(this.serverUrl + 'Items/GetItems')
      .subscribe((response) => {
        this.Items = response as Item[];
      });
  }
  ngOnInit(): void {
    this.getItemsList();
  }


  addItem() {

    this.http.post(this.serverUrl + 'Items/CreateItem',
      {
        itemName: this.newItemName,
        price: this.newItemPrice
      })
      .subscribe((response) => {
        console.log(response);
        this.getItemsList();
      });
  }

  removeItem(id: number) {
    const url = `${this.serverUrl}Items/DeleteItem?id=${id}`;

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
}

export interface Item {
  id: number
  createdAt: string
  modifiedAt: string
  isDeleted: boolean
  productName: string
  unitPrice: number
}
