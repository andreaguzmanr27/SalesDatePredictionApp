import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { OrdersComponent } from './orders/orders.component';
import { OrderPredictionsComponent } from './order-predictions/order-predictions.component';
import { NewOrderComponent } from './new-order/new-order.component';

const routes: Routes = [
  { path: '', component: OrderPredictionsComponent },
  { path: 'customer-orders/:customerName', component: OrdersComponent },
  { path: 'new-order/:customerName', component: NewOrderComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
