import { ComponentFixture, TestBed } from '@angular/core/testing';

import { OrderPredictionsComponent } from './order-predictions.component';

describe('OrderPredictionsComponent', () => {
  let component: OrderPredictionsComponent;
  let fixture: ComponentFixture<OrderPredictionsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [OrderPredictionsComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(OrderPredictionsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
