import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, catchError } from 'rxjs';
import { environment } from 'src/environments/environment';
import { NpvCalculationQuery } from '../model/npv-calculation-query.model';

@Injectable({
  providedIn: 'root',
})
export class NpvCalculationService {
  private readonly url = `${environment.npvCalculationApiUrl}/npvcalculation`;

  constructor(private http: HttpClient) {}

  getNpvCalculationById(id: number): Observable<NpvCalculationQuery> {
    return this.http.get<NpvCalculationQuery>(`${this.url}/${id}`).pipe(
      catchError((error) => {
        throw error;
      })
    );
  }
}
