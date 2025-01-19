import {Component, NgModule} from '@angular/core';
import { RouterOutlet } from '@angular/router';
import {ItemsComponent} from './items/items.component';
import {CartComponent} from './cart/cart.component';

@Component({
  selector: 'app-root',
  imports: [RouterOutlet],
  templateUrl: './app.component.html',
  standalone: true
})
@NgModule({
  declarations: [
    ItemsComponent,
    CartComponent
  ],
  bootstrap: [ItemsComponent],
  exports: [
    ItemsComponent
  ],
  // если это главный компонент
})
export class AppModule {}
export class AppComponent {

}
