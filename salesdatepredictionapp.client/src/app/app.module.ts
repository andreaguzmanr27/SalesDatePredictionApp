import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { OrdersComponent } from './orders/orders.component';
import { OrderPredictionsComponent } from './order-predictions/order-predictions.component';
import { NewOrderComponent } from './new-order/new-order.component';

@NgModule({
  imports: [
    AppComponent, OrdersComponent, OrderPredictionsComponent, NewOrderComponent,
    BrowserModule, HttpClientModule,
    AppRoutingModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
