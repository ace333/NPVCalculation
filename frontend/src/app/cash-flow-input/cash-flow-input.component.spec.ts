import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CashFlowInputComponent } from './cash-flow-input.component';

describe('CashFlowInputComponent', () => {
  let component: CashFlowInputComponent;
  let fixture: ComponentFixture<CashFlowInputComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ CashFlowInputComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(CashFlowInputComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
