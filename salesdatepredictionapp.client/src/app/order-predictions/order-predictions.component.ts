import { Component } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';
import { CommonModule } from '@angular/common';
import { OrdersComponent } from '../orders/orders.component';
import { NewOrderComponent } from '../new-order/new-order.component';
import { NgxPaginationModule, PaginationInstance } from 'ngx-pagination';
import { FormsModule } from '@angular/forms'; 

interface OrderPrediction {
  customerName: string;
  lastOrderDate: string;
  nextPredictedOrder: string;
}

@Component({
  selector: 'app-order-predictions',
  imports: [CommonModule, OrdersComponent, NewOrderComponent, NgxPaginationModule, FormsModule],
  templateUrl: './order-predictions.component.html',
  styleUrl: './order-predictions.component.css'
})

export class OrderPredictionsComponent {
  public orderPredictions: OrderPrediction[] = [];
  showOrdersModal: boolean = false;
  showNewOrderModal: boolean = false;
  selectedCustomerName: string = '';
  sortColumn: string = '';
  sortDirection: boolean = true;
  searchTerm: string = '';

  constructor(
    private http: HttpClient,
    private router: Router
  ) { }

  ngOnInit() {
    setTimeout(() => {
      this.getOrderPredictions();
    }, 3000);
  }

  getOrderPredictions() {
    const body = { CustomerName: this.searchTerm };
    this.http.post<OrderPrediction[]>('/orderprediction/UpdateSalesDatePrediction', body).subscribe(
      (result) => {
        this.orderPredictions = result;
      },
      (error) => {
        console.error(error);
      }
    );
  }

  openOrdersModal(customerName: string): void {
    this.selectedCustomerName = customerName;
    this.showOrdersModal = true;
  }

  closeOrdersModal(): void {
    this.showOrdersModal = false;
  }

  openNewOrderModal(customerName: string): void {
    this.selectedCustomerName = customerName;
    this.showNewOrderModal = true;
  }

  closeNewOrderModal(): void {
    this.showNewOrderModal = false;
  }

  parentPaginationConfig: PaginationInstance = {
    id: 'parent-pagination',
    itemsPerPage: 10,
    currentPage: 1
  };

  getPaginationSummary(totalItems: number, itemsPerPage: number, currentPage: number): string {
    if (totalItems === 0) return "No data available";

    const start = (currentPage - 1) * itemsPerPage + 1;
    const end = Math.min(start + itemsPerPage - 1, totalItems);
    return `${start}-${end} of ${totalItems}`;
  }

  updatePagination() {
    this.parentPaginationConfig.currentPage = 1;
    this.parentPaginationConfig.itemsPerPage = Number(this.parentPaginationConfig.itemsPerPage);
    this.getPaginationSummary(this.orderPredictions.length, this.parentPaginationConfig.itemsPerPage, this.parentPaginationConfig.currentPage);
  }

  sortBy(column: keyof OrderPrediction) {
    if (this.sortColumn === column) {
      this.sortDirection = !this.sortDirection;
    } else {
      this.sortColumn = column;
      this.sortDirection = true;
    }

    this.orderPredictions.sort((a, b) => {
      const valueA = a[column];
      const valueB = b[column];

      if (typeof valueA === 'string' && typeof valueB === 'string') {
        return this.sortDirection ? valueA.localeCompare(valueB) : valueB.localeCompare(valueA);
      } else {
        return this.sortDirection ? +valueA - +valueB : +valueB - +valueA;
      }
    });
  }

}
