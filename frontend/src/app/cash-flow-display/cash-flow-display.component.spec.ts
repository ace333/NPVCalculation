import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CashFlowDisplayComponent } from './cash-flow-display.component';

describe('CashFlowDisplayComponent', () => {
  let component: CashFlowDisplayComponent;
  let fixture: ComponentFixture<CashFlowDisplayComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ CashFlowDisplayComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(CashFlowDisplayComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
