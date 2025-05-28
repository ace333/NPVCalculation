export interface NpvCalculationGraph {
  name: string;
  series: NpvCalculationGraphElement[];
}

export interface NpvCalculationGraphElement {
  name: string;
  value: number;
}
