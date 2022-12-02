import { Category } from "./category";

export interface Thing {
    id?: number,
    description: string,
    name: string,
    color: string,
    quantity: number,
    category: Category
}
