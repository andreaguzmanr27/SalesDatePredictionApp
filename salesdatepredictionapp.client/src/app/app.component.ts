import { Component } from '@angular/core';
import { OrderPredictionsComponent } from './order-predictions/order-predictions.component';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css'],
  imports: [ OrderPredictionsComponent ]
})
export class AppComponent {
  title = 'salesdatepredictionapp.client';
}
