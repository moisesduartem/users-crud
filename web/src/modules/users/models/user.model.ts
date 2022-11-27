import { Scholarity } from "../enums/scholarity.enum";

export interface User {
    id: number;
    firstName: string;
    lastName: string;
    email: string;
    birthDate: string;
    scholarity: Scholarity;
}