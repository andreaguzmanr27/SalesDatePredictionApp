import { Component, Input, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { CommonModule } from '@angular/common';
import { NgxPaginationModule, PaginationInstance } from 'ngx-pagination';
import { FormsModule } from '@angular/forms';

interface Order {
  orderid: number;
  requireddate: string;
  shippeddate: string;
  shipname: string;
  shipaddress: string;
  shipcity: string;
}

@Component({
  selector: 'app-orders',
  templateUrl: './orders.component.html',
  styleUrls: ['./orders.component.css'],
  imports: [CommonModule, NgxPaginationModule, FormsModule]
})

export class OrdersComponent implements OnInit {
  @Input() customerName: string = '';
  orders: Order[] = [];
  sortColumn: string = '';
  sortDirection: boolean = true;

  constructor(private http: HttpClient) { }

  ngOnInit(): void {
    if (this.customerName) {
      this.loadOrders();
    }
  }

  loadOrders(): void {
    this.http.get<Order[]>(`/orders/${this.customerName}`).subscribe(
      (orders) => {
        this.orders = orders;
      },
      (error) => {
        console.error('Error al obtener las órdenes:', error);
      }
    );
  }

  childPaginationConfig: PaginationInstance = {
    id: 'child-pagination',
    itemsPerPage: 10,
    currentPage: 1
  };

  getPaginationSummary(totalItems: number, itemsPerPage: number, currentPage: number): string {
    if (totalItems === 0) return "No data available";

    const start = (currentPage - 1) * itemsPerPage + 1;
    const end = Math.min(start + itemsPerPage - 1, totalItems);
    return `${start}-${end} of ${totalItems}`;
  }

  updatePage(pageNumber: number) {
    this.childPaginationConfig.currentPage = pageNumber;
    this.childPaginationConfig.itemsPerPage = Number(this.childPaginationConfig.itemsPerPage);
    this.getPaginationSummary(this.orders.length, this.childPaginationConfig.itemsPerPage, this.childPaginationConfig.currentPage);
  }

  updatePagination(event: any) {
    this.childPaginationConfig.currentPage = 1;
    this.childPaginationConfig.itemsPerPage = Number(event.target.value);
    this.getPaginationSummary(this.orders.length, this.childPaginationConfig.itemsPerPage, this.childPaginationConfig.currentPage);
  }

  sortBy(column: keyof Order) {
    if (this.sortColumn === column) {
      this.sortDirection = !this.sortDirection;
    } else {
      this.sortColumn = column;
      this.sortDirection = true;
    }

    this.orders.sort((a, b) => {
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


