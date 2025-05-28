export interface CashFlowCommand {
  cashFlowValues: number[];
  lowerBoundDiscountRate: number;
  upperBoundDiscountRate: number;
  increment: number;
}
