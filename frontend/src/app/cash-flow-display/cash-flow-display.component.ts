import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { NpvCalculationService } from '../api-services/npv-calculation.service';
import { switchMap } from 'rxjs';
import { NpvCalculation } from '../model/npv-calculation.model';
import { NpvCalculationQuery } from '../model/npv-calculation-query.model';
import {
  NpvCalculationGraph,
  NpvCalculationGraphElement,
} from '../model/npv-calculation-graph.model';

@Component({
  selector: 'app-cash-flow-display',
  templateUrl: './cash-flow-display.component.html',
  styleUrls: ['./cash-flow-display.component.scss'],
})
export class CashFlowDisplayComponent {
  npvCalcuation: NpvCalculationGraph[] | undefined;

  // options
  view = [700, 300];
  legend: boolean = true;
  showLabels: boolean = true;
  animations: boolean = true;
  xAxis: boolean = true;
  yAxis: boolean = true;
  showYAxisLabel: boolean = true;
  showXAxisLabel: boolean = true;
  xAxisLabel: string = 'Rate';
  yAxisLabel: string = 'Npv calculation';
  timeline: boolean = true;

  colorScheme = {
    domain: ['#5AA454', '#E44D25', '#CFC0BB', '#7aa3e5', '#a8385d', '#aae3f5'],
  };

  constructor(
    private activatedRoute: ActivatedRoute,
    private npvCalculationApi: NpvCalculationService
  ) {
    this.activatedRoute.params
      .pipe(
        switchMap((params) =>
          this.npvCalculationApi.getNpvCalculationById(params['id'])
        )
      )
      .subscribe((npvCalculation: NpvCalculationQuery) => {
        this.npvCalcuation = [{
          name: 'Npv Calculation',
          series: npvCalculation.npvCalculations.map((x) => {
            return {
              name: x.rate.toString(),
              value: x.npvCalculation,
            } as NpvCalculationGraphElement;
          }),
        } as NpvCalculationGraph];
      });
  }
}
