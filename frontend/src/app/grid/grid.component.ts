import { Component } from '@angular/core';
import { Observable, catchError, filter, first } from 'rxjs';
import { PageInfo } from '../model/page-info.model';
import { PageEvent } from '@angular/material/paginator';
import { Router } from '@angular/router';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { HttpErrorResponse } from '@angular/common/http';
import { CashFlow } from '../model/cash-flow.model';
import { CashFlowService } from '../api-services/cash-flow.service';
import { CashFlowQuery } from '../model/cash-flow-query.model';
import { NpvCalculation } from '../model/npv-calculation.model';

@Component({
  selector: 'app-grid',
  templateUrl: './grid.component.html',
  styleUrls: ['./grid.component.scss'],
})
export class GridComponent {
  displayedColumns: string[] = [
    'id',
    'lowerBoundDiscountRate',
    'upperBoundDiscountRate',
    'increment',
    'hasNpvCalculation'
  ];
  cashFlows: CashFlow[] = [];
  lastPageEvent: PageEvent | undefined;
  pageInfo: PageInfo = { totalRecords: 0 } as PageInfo;

  constructor(
    private cashFlowApi: CashFlowService,
    private router: Router
  ) {
    this.getCashFlows(0, 0);
  }

  onPageChange($event: PageEvent): void {
    this.lastPageEvent = $event;
    this.getCashFlows($event.pageSize, $event.pageIndex * $event.pageSize);
  }

  onRowClick($event: CashFlow) {
    if($event.hasNpvCalculation) {
      this.router.navigate(['cashflow', $event.id]);
    }
  }

  onTriggerNpvCalculation(id: number): void {
    this.cashFlowApi
      .triggerNpvCalculation(id).pipe(
        catchError((error) => {
          throw error;
        }),
      )
      .subscribe(() => {
        this.getCashFlows(this.lastPageEvent?.pageSize ?? 0, this.lastPageEvent ? this.lastPageEvent?.pageIndex * this.lastPageEvent?.pageSize : 0);
      });
  }

  private getCashFlows(limit: number, offset: number): void {
    this.cashFlowApi
      .getCashFlows(limit, offset)
      .pipe(
        catchError((error) => {
          throw error;
        }),
        filter((result: CashFlowQuery) => !!result)
      )
      .subscribe((result: CashFlowQuery) => {
        this.cashFlows = result.items;
        this.pageInfo = result.pageInfo;
      });
  }
}
