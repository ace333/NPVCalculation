import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { GridComponent } from './grid/grid.component';
import { CashFlowInputComponent } from './cash-flow-input/cash-flow-input.component';
import { CashFlowDisplayComponent } from './cash-flow-display/cash-flow-display.component';

const routes: Routes = [
  {
    path: '',
    redirectTo: 'grid',
    pathMatch: 'full',
  },
  {
    path: 'grid',
    component: GridComponent,
  },
  {
    path: 'cashflow-new',
    component: CashFlowInputComponent
  },
  {
    path: 'cashflow/:id',
    component: CashFlowDisplayComponent
  },
  {
    path: '**',
    redirectTo: 'grid',
  },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
