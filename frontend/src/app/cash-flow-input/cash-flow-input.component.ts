import { Component, OnInit } from '@angular/core';
import { FormArray, FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { CashFlowService } from '../api-services/cash-flow.service';
import { Router } from '@angular/router';
import { catchError } from 'rxjs';
import { HttpErrorResponse } from '@angular/common/http';
import { CashFlowCommand } from '../model/cash-flow-command.model';

@Component({
  selector: 'app-cash-flow-input',
  templateUrl: './cash-flow-input.component.html',
  styleUrls: ['./cash-flow-input.component.scss']
})
export class CashFlowInputComponent {
  cashFlowForm: FormGroup = this.formBuilder.group({
    cashFlows: this.formBuilder.array([
      this.createCashFlowControl()
    ]),
    lowerBoundDiscountRate: new FormControl('', [Validators.required, Validators.min(0)]),
    upperBoundDiscountRate: new FormControl('', [Validators.required, Validators.min(0)]),
    increment: new FormControl('', [Validators.required, Validators.min(0)])
  });

  constructor(
    private cashFlowApi: CashFlowService,
    private formBuilder: FormBuilder,
    private router: Router
  ) {}

  onCreateClick(): void {
    if (this.cashFlowForm.valid) {
      var command = { ...this.cashFlowForm.value, cashFlowValues: this.getCashFlowValues() } as CashFlowCommand;
      this.cashFlowApi
        .createCashFlow(command)
        .pipe(
          catchError((error: HttpErrorResponse) => {
            if(error.status === 400) {
              alert(error.error);
            }
            throw error;
          })
        )
        .subscribe(() => {
          this.router.navigate(['grid']);
        });
    }
  }

  private createCashFlowControl(): FormGroup {
    return this.formBuilder.group({
      value: [null, [Validators.required, Validators.min(0)]]
    });
  }

  get cashFlows(): FormArray {
    return this.cashFlowForm.get('cashFlows') as FormArray;
  }

  addCashFlow(): void {
    this.cashFlows.push(this.createCashFlowControl());
  }

  removeCashFlow(index: number): void {
    this.cashFlows.removeAt(index);
  }

  getCashFlowValues(): number[] {
    return this.cashFlows.controls.map(ctrl => ctrl.value.value);
  }

}
