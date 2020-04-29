import { Dish } from './dish.model';

export class Order{
    constructor(
        public dishList: Dish[],
        public amount: number,
        public firstName: string,
        public secondName: string,
        public adress: string
    ){}
}