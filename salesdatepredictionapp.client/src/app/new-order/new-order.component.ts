import { Component, Input, Output, OnInit, EventEmitter } from '@angular/core';
import { FormBuilder, FormGroup, Validators, ReactiveFormsModule } from '@angular/forms';
import { HttpClient } from '@angular/common/http';
import { CommonModule } from '@angular/common';

interface Employee {
  empid: number;
  fullName: string;
}
interface Shipper {
  shipperid: number;
  companyname: string;
}
interface Product {
  productid: number;
  productname: string;
}

@Component({
  selector: 'app-new-order',
  templateUrl: './new-order.component.html',
  styleUrl: './new-order.component.css',
  imports: [CommonModule, ReactiveFormsModule]
})
export class NewOrderComponent implements OnInit {
  @Input() customerName: string = '';
  @Output() closeModal = new EventEmitter<void>();

  onClose() {
    this.closeModal.emit();
  }
  orderForm!: FormGroup;
  employees: Employee[] = [];
  shippers: Shipper[] = [];
  products: Product[] = [];

  constructor(
    private fb: FormBuilder,
    private http: HttpClient,
  ) { }

  ngOnInit(): void {
    this.loadEmployees();
    this.loadShippers();
    this.loadProducts();

    this.orderForm = this.fb.group({
      empid: ['', Validators.required],
      shipperid: ['', Validators.required],
      shipname: ['', Validators.required],
      shipaddress: ['', Validators.required],
      shipcity: ['', Validators.required],
      orderdate: ['', Validators.required],
      requireddate: ['', Validators.required],
      shippeddate: [null],
      freight: ['', [Validators.required, Validators.pattern('^\\d+(\\.\\d{1,2})?$')]],
      shipcountry: ['', Validators.required],
      productid: ['', Validators.required],
      unitprice: ['', [Validators.required, Validators.pattern('^\\d+(\\.\\d{1,2})?$')]],
      qty: ['', [Validators.required, Validators.min(1)]],
      discount: ['', [Validators.required, Validators.pattern('^\\d+(\\.\\d{1,2})?$')]]
    });
  }

  loadEmployees() {
    this.http.get<Employee[]>('/employees').subscribe(
      (result) => {
        this.employees = result;
      },
      (error) => {
        console.error(error);
      }
    );
  }

  loadShippers() {
    this.http.get<Shipper[]>('/shippers').subscribe(
      (result) => {
        this.shippers = result;
      },
      (error) => {
        console.error(error);
      }
    );
  }

  loadProducts() {
    this.http.get<Product[]>('/products').subscribe(
      (result) => {
        this.products = result;
      },
      (error) => {
        console.error(error);
      }
    );
  }

  submitOrder() {
    if (this.orderForm.valid) {
      const formData = {
        ...this.orderForm.value,
        CustomerName: this.customerName
      };

      this.http.post("/orders/addneworder", formData).subscribe({
        next: (response) => {
          alert("✅ Orden creada con éxito!");
          this.closeModal.emit();
        },
        error: (error) => {
          alert("❌ Error al crear la orden.");
        }
      });
    } else {
      alert("⚠️ Formulario inválido. Revisa los campos.");
    }
  }

  setDateType(event: any) {
    event.target.type = 'date';
  }

  resetDateType(event: any) {
    if (!event.target.value) {
      event.target.type = 'text';
    }
  }
}
