import { Person } from "./person";
import { Thing } from "./thing";

export interface Loan {
    id?: number,
    thing: Thing,
    person: Person,
    borrowedAmount: number
}
