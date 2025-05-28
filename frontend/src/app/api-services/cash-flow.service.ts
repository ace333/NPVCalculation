import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { CashFlowQuery } from '../model/cash-flow-query.model';
import { Observable, catchError } from 'rxjs';
import { CashFlowCommand } from '../model/cash-flow-command.model';

@Injectable({
  providedIn: 'root',
})
export class CashFlowService {
  private readonly url = `${environment.cashFlowApiUrl}/cashflow`;

  constructor(private http: HttpClient) {}

  getCashFlows(limit: number, offset: number): Observable<CashFlowQuery> {
    const params = { limit, offset };

    return this.http.get<CashFlowQuery>(this.url, { params }).pipe(
      catchError((error) => {
        throw error;
      })
    );
  }

  createCashFlow(cashFlowCommand: CashFlowCommand): Observable<void> {
    return this.http.post<void>(this.url, cashFlowCommand).pipe(
      catchError((error) => {
        throw error;
      })
    );
  }

  triggerNpvCalculation(cashFlowId: number): Observable<void> {
    return this.http.post<void>(`${this.url}/trigger`, { cashFlowId }).pipe(
      catchError((error) => {
        throw error;
      })
    );
  }
}
