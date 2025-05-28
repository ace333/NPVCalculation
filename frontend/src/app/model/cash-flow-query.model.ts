import { CashFlow } from "./cash-flow.model";
import { PageInfo } from "./page-info.model";

export interface CashFlowQuery {
  pageInfo: PageInfo;
  items: CashFlow[];
}
