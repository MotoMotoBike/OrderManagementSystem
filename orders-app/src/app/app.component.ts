import { HttpClientModule } from '@angular/common/http';
import { Component } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import {FormsModule} from '@angular/forms';
import {CommonModule} from '@angular/common';
import {RouterOutlet} from '@angular/router';
import { Router } from '@angular/router';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [HttpClientModule, FormsModule, CommonModule, RouterOutlet],
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})

export class AppComponent {
  host = 'http://localhost:5091/';

  Items: Item[] = [];

  newItemName = "";
  newItemPrice = 0;
  constructor(private http: HttpClient,
              private router: Router) {
  }

  getItemsList() {
    this.http.get(this.host + 'api/Items/GetItems')
      .subscribe((response) => {
        this.Items = response as Item[];
      });
  }
  ngOnInit(): void {
    this.getItemsList();
  }


  addItem() {

    this.http.post(this.host + 'api/Items/CreateItem',
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
    const url = `${this.host}api/Items/DeleteItem?id=${id}`;

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
