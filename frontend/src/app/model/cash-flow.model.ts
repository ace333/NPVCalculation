export interface CashFlow {
  id: number;
  lowerBoundDiscountRate: number;
  upperBoundDiscountRate: number;
  increment: number;
  hasNpvCalculation: boolean;
}
